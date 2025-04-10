﻿// <auto-generated />
using System;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(UsersDbContext))]
    partial class UsersDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

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
                            Id = new Guid("3d333144-c00a-490f-970c-aa995da67100"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "db52f37f-924e-42af-ab5f-1bca57412bbd",
                            CreatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2569),
                            Email = "example1@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "John",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE1@GMAIL.COM",
                            NormalizedUserName = "JOHN",
                            PasswordHash = "$2a$11$.fY72scmAdUZ2leBi5.O/Op2XbpJnFMh2n.LdeoY246Pa6Rt/uDO2",
                            PhoneNumber = "(99) 99999-9991",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7841ebd5-6212-48f6-a6b2-aa472f01ccc2",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 116, DateTimeKind.Local).AddTicks(9351),
                            UserName = "john"
                        },
                        new
                        {
                            Id = new Guid("9b133a03-3800-4248-b129-4d74a60d8395"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b863f86-88cf-4e75-b081-2ef902a1dadd",
                            CreatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3052),
                            Email = "example2@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Jane",
                            LastName = "Doe",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE2@GMAIL.COM",
                            NormalizedUserName = "JANE",
                            PasswordHash = "$2a$11$ioHWq/EohvquKoiZlGW2SeUthdzBRHxRavz64jPADk2wAj5cTgv9O",
                            PhoneNumber = "(99) 99999-9992",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8847620b-0885-4b56-8a87-68e9f0548727",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2994),
                            UserName = "jane"
                        },
                        new
                        {
                            Id = new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5fe5ed19-8167-4b69-b38c-9d8f6a076012",
                            CreatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3065),
                            Email = "example3@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Alice",
                            LastName = "Anderson",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE3@GMAIL.COM",
                            NormalizedUserName = "ALICE",
                            PasswordHash = "$2a$11$/e8R1TfwYfT6XsB7Zddmo.KynrAEY.TIrbpjigDGW5FQgvyBM2ptS",
                            PhoneNumber = "(99) 99999-9993",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "546d828d-a70e-4012-a6e9-8beac0552599",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3056),
                            UserName = "alice"
                        },
                        new
                        {
                            Id = new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "020c0d83-b132-45e0-bc26-a5b64941d899",
                            CreatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3075),
                            Email = "example4@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Bob",
                            LastName = "Anderson",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE4@GMAIL.COM",
                            NormalizedUserName = "BOB",
                            PasswordHash = "$2a$11$27zZAGL4qvzhThokBox8ieggp7l8UGPEu9YpM/4giov2rM33bLA8a",
                            PhoneNumber = "(99) 99999-9994",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b89df511-3e8d-404a-9e1e-e7f7ce66d508",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3067),
                            UserName = "bob"
                        },
                        new
                        {
                            Id = new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "650cce00-1734-4585-bc30-a25474e282a8",
                            CreatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3087),
                            Email = "example5@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Charlie",
                            LastName = "Smith",
                            LockoutEnabled = false,
                            NormalizedEmail = "EXAMPLE5@GMAIL.COM",
                            NormalizedUserName = "CHARLIE",
                            PasswordHash = "$2a$11$B/ngxiWj0FCSa/osLPYBAez8k6ntJjUhNbyAjGcGFUNmr0ak.W8Vm",
                            PhoneNumber = "(99) 99999-9995",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "553b8b44-52e4-4f09-99f8-d225f03d3433",
                            Status = 0,
                            TwoFactorEnabled = false,
                            UpdatedAt = new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3079),
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
                            Id = new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"),
                            ConcurrencyStamp = "431e73e6-5238-4024-8141-5355c5e91d52",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"),
                            ConcurrencyStamp = "dbfcf47c-59be-4b08-a9ca-fbbdb18bd6d9",
                            Name = "Owner",
                            NormalizedName = "OWNER"
                        },
                        new
                        {
                            Id = new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"),
                            ConcurrencyStamp = "aa23e890-96a6-4557-82a2-eae8ebade3cb",
                            Name = "Consultant",
                            NormalizedName = "CONSULTANT"
                        },
                        new
                        {
                            Id = new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"),
                            ConcurrencyStamp = "a06d95f3-9c52-4a39-ad2a-4085ec83e764",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"),
                            ConcurrencyStamp = "3d58d68b-3852-40d9-9c40-e0f0565ec68e",
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
                            UserId = new Guid("3d333144-c00a-490f-970c-aa995da67100"),
                            RoleId = new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606")
                        },
                        new
                        {
                            UserId = new Guid("9b133a03-3800-4248-b129-4d74a60d8395"),
                            RoleId = new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691")
                        },
                        new
                        {
                            UserId = new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"),
                            RoleId = new Guid("001496cf-cac1-4343-815c-c929c4b75dc8")
                        },
                        new
                        {
                            UserId = new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"),
                            RoleId = new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f")
                        },
                        new
                        {
                            UserId = new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"),
                            RoleId = new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9")
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
