using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public interface IUsersDbContext
    {
        public DbSet<User> IdentityUsers { get; set; }
    }
}