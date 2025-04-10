using Core.Entities;
using Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class UsersDbContext(DbContextOptions<UsersDbContext> options) : IdentityDbContext<User, IdentityRole<Guid>, Guid>(options), IUsersDbContext, IReceitaDbContext, IDespesaDbContext
    {
        public DbSet<User> IdentityUsers { get; set; }

        public DbSet<Receitas> Receitas { get; set; }
        public DbSet<Despesas> Despesas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            List<Guid> roleIds = [];
            Dictionary<string, object> roles = [];

            foreach (var role in RoleExtension.GetValues())
            {
                var roleId = Guid.NewGuid();
                roles.Add(role.ToFriendlyString(), new
                {
                    Id = roleId,
                    Name = role.ToString(),
                    NormalizedName = role.ToString().ToUpper()
                });
                roleIds.Add(roleId);
            }

            foreach (var role in roles)
            {
                modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
                {
                    Id = (Guid)role.Value.GetType().GetProperty("Id")!.GetValue(role.Value)!,
                    Name = (string)role.Value.GetType().GetProperty("Name")!.GetValue(role.Value)!,
                    NormalizedName = role.Value.GetType().GetProperty("NormalizedName")!.GetValue(role.Value)!.ToString()!.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }

            List<User> users =
            [
                new User("John", "Doe", "example1@gmail.com", "(99) 99999-9991"),
                new User("Jane", "Doe", "example2@gmail.com", "(99) 99999-9992"),
                new User("Alice", "Anderson", "example3@gmail.com", "(99) 99999-9993"),
                new User("Bob", "Anderson", "example4@gmail.com", "(99) 99999-9994"),
                new User("Charlie", "Smith", "example5@gmail.com", "(99) 99999-9995")
            ];

            foreach (var user in users)
            {
                user.UserName = user.FirstName.ToLower();
                user.NormalizedUserName = user.UserName.ToUpper();
                user.NormalizedEmail = user.Email!.ToUpper();
                user.SecurityStamp = Guid.NewGuid().ToString();
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword("test123");
            }

            modelBuilder.Entity<User>().HasData(users);

            for (int i = 0; i < users.Count; i++)
            {
                modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
                {
                    UserId = users[i].Id,
                    RoleId = roleIds[i]
                });
            }

            modelBuilder.Entity<Receitas>(entity => { 

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Fonte).IsRequired().HasMaxLength(50);

                entity.Property(e => e.Valor).IsRequired();

                entity.Property(e => e.Descricao).HasMaxLength(100);

                entity.Property(e => e.Data).IsRequired();

            });
            
            modelBuilder.Entity<Despesas>(entity => { 

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Categoria).IsRequired().HasMaxLength(50);

                entity.Property(e => e.Valor).IsRequired();

                entity.Property(e => e.Descricao).HasMaxLength(100);

                entity.Property(e => e.Data).IsRequired();

            }
            );
        }
    }
}
