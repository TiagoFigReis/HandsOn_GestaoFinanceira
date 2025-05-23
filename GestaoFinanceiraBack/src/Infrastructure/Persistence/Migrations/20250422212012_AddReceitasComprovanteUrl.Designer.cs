﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    [Migration("20250422212012_AddReceitasComprovanteUrl")]
    partial class AddReceitasComprovanteUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Despesas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("Categoria")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Despesas");
                });

            modelBuilder.Entity("Core.Entities.Receitas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ComprovanteUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Fonte")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("Receitas");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "edb7b82a-2ed9-4865-aa05-518578b69092",
                            CreatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8668),
                            Email = "example1@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE1@GMAIL.COM",
                            NormalizedUserName = "JOHN",
                            PasswordHash = "$2a$11$Orw6AOYridQTbwhLQMqh5OIp28oOG5wGEPz/eKkwnva6S0x8jLPlK",
                            PhoneNumber = "(99) 99999-9991",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "39e74c8d-8118-4c87-8aca-2d1020f8602a",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(6609),
                            UserName = "john"
                        },
                        new
                        {
                            Id = new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "eea2990f-f6f1-4d45-800a-4917631e53f3",
                            CreatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8953),
                            Email = "example2@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE2@GMAIL.COM",
                            NormalizedUserName = "JANE",
                            PasswordHash = "$2a$11$khh9To8KX5gooYMSdrs86u9yabxSxcv84Aar4NKbhvmGOf79yS5DW",
                            PhoneNumber = "(99) 99999-9992",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "815600cc-ddb3-4fe2-be36-efc5fb047781",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8934),
                            UserName = "jane"
                        },
                        new
                        {
                            Id = new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "bb44674f-d713-4b78-9272-1b11e85b8276",
                            CreatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8957),
                            Email = "example3@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Alice",
                            LastName = "Anderson",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE3@GMAIL.COM",
                            NormalizedUserName = "ALICE",
                            PasswordHash = "$2a$11$JENmu5eqXlYrKSJemcevreoLMyC1PT.EIQnHnSyhBYTaRH/hcHOtW",
                            PhoneNumber = "(99) 99999-9993",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9253fc4f-7227-4e32-9cd2-61c811d537be",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8954),
                            UserName = "alice"
                        },
                        new
                        {
                            Id = new Guid("2946f55e-4022-417e-bdfe-62f11709a181"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "9b4b86d2-3ff8-4dc4-87cc-8fb9d296265b",
                            CreatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8961),
                            Email = "example4@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Bob",
                            LastName = "Anderson",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE4@GMAIL.COM",
                            NormalizedUserName = "BOB",
                            PasswordHash = "$2a$11$GFqPO9WdqSxAcBNyqucfYOxEcNcBOMpZI6qf/80/4qJ1og/rerI/y",
                            PhoneNumber = "(99) 99999-9994",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "9911b41e-7019-41d6-9abe-0d71f6d87f9e",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8958),
                            UserName = "bob"
                        },
                        new
                        {
                            Id = new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "d1453d25-943f-42ea-87b8-f95d4fd6119b",
                            CreatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8969),
                            Email = "example5@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Charlie",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE5@GMAIL.COM",
                            NormalizedUserName = "CHARLIE",
                            PasswordHash = "$2a$11$.g.KCjsYFYkvbH9JT8OUFu2JS1lt61y80PAoU2DYqDdmohcqC19pm",
                            PhoneNumber = "(99) 99999-9995",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "59955f08-c833-45d9-a2e0-5af84c5d2c3b",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8962),
                            UserName = "charlie"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625"),
                            ConcurrencyStamp = "ec0da946-9a24-4cb9-8c8c-69aa36745348",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909"),
                            ConcurrencyStamp = "99b08bdc-750c-4a95-8fd2-76dbe94776b2",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52"),
                            ConcurrencyStamp = "f6b7502a-9615-4c87-a6e3-f59790d31507",
                            Name = "Consultant",
                            NormalizedName = "CONSULTANT"
                        },
                        new
                        {
                            Id = new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5"),
                            ConcurrencyStamp = "ae305c23-485b-4626-ac80-4c0d970217e3",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf"),
                            ConcurrencyStamp = "d04ecead-fab5-454c-8d0e-ef99854517a9",
                            Name = "Collaborator",
                            NormalizedName = "COLLABORATOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622"),
                            RoleId = new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625")
                        },
                        new
                        {
                            UserId = new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b"),
                            RoleId = new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909")
                        },
                        new
                        {
                            UserId = new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7"),
                            RoleId = new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52")
                        },
                        new
                        {
                            UserId = new Guid("2946f55e-4022-417e-bdfe-62f11709a181"),
                            RoleId = new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5")
                        },
                        new
                        {
                            UserId = new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6"),
                            RoleId = new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
