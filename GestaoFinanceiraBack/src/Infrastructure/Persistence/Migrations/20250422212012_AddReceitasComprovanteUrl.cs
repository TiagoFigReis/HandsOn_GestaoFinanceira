using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReceitasComprovanteUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3615c2dc-eb32-4e31-a5af-8db08a89e354"), new Guid("5c342a05-0460-4d74-9af5-9d6d6d81fa12") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5ca2dfda-9efd-4a18-b0e6-c6895c819dc7"), new Guid("5e91068e-29df-40af-b355-fb85020747db") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f58e5136-55b5-4d24-9ef6-bebd53e9dca3"), new Guid("66d9ed24-258d-41fe-97df-0c8309eaadc6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("65cad716-abc5-4a76-b99d-2c6e8843dc7b"), new Guid("8c040141-bb0c-4a7f-87f0-2d00bd592f03") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7654ea20-52d4-4612-ba1f-aa8274eb779b"), new Guid("fbdf5d81-1ab1-431f-87f9-c1e275a31e49") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3615c2dc-eb32-4e31-a5af-8db08a89e354"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5ca2dfda-9efd-4a18-b0e6-c6895c819dc7"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("65cad716-abc5-4a76-b99d-2c6e8843dc7b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7654ea20-52d4-4612-ba1f-aa8274eb779b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f58e5136-55b5-4d24-9ef6-bebd53e9dca3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5c342a05-0460-4d74-9af5-9d6d6d81fa12"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e91068e-29df-40af-b355-fb85020747db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66d9ed24-258d-41fe-97df-0c8309eaadc6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c040141-bb0c-4a7f-87f0-2d00bd592f03"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("fbdf5d81-1ab1-431f-87f9-c1e275a31e49"));

            migrationBuilder.UpdateData(
                table: "Receitas",
                keyColumn: "Descricao",
                keyValue: null,
                column: "Descricao",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Receitas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ComprovanteUrl",
                table: "Receitas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5"), "ae305c23-485b-4626-ac80-4c0d970217e3", "Manager", "MANAGER" },
                    { new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625"), "ec0da946-9a24-4cb9-8c8c-69aa36745348", "Admin", "ADMIN" },
                    { new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf"), "d04ecead-fab5-454c-8d0e-ef99854517a9", "Collaborator", "COLLABORATOR" },
                    { new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52"), "f6b7502a-9615-4c87-a6e3-f59790d31507", "Consultant", "CONSULTANT" },
                    { new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909"), "99b08bdc-750c-4a95-8fd2-76dbe94776b2", "Owner", "OWNER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7"), 0, "bb44674f-d713-4b78-9272-1b11e85b8276", new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8957), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$JENmu5eqXlYrKSJemcevreoLMyC1PT.EIQnHnSyhBYTaRH/hcHOtW", "(99) 99999-9993", false, "9253fc4f-7227-4e32-9cd2-61c811d537be", 0, false, new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8954), "alice" },
                    { new Guid("2946f55e-4022-417e-bdfe-62f11709a181"), 0, "9b4b86d2-3ff8-4dc4-87cc-8fb9d296265b", new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8961), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$GFqPO9WdqSxAcBNyqucfYOxEcNcBOMpZI6qf/80/4qJ1og/rerI/y", "(99) 99999-9994", false, "9911b41e-7019-41d6-9abe-0d71f6d87f9e", 0, false, new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8958), "bob" },
                    { new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622"), 0, "edb7b82a-2ed9-4865-aa05-518578b69092", new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8668), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$Orw6AOYridQTbwhLQMqh5OIp28oOG5wGEPz/eKkwnva6S0x8jLPlK", "(99) 99999-9991", false, "39e74c8d-8118-4c87-8aca-2d1020f8602a", 0, false, new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(6609), "john" },
                    { new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6"), 0, "d1453d25-943f-42ea-87b8-f95d4fd6119b", new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8969), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$.g.KCjsYFYkvbH9JT8OUFu2JS1lt61y80PAoU2DYqDdmohcqC19pm", "(99) 99999-9995", false, "59955f08-c833-45d9-a2e0-5af84c5d2c3b", 0, false, new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8962), "charlie" },
                    { new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b"), 0, "eea2990f-f6f1-4d45-800a-4917631e53f3", new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8953), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$khh9To8KX5gooYMSdrs86u9yabxSxcv84Aar4NKbhvmGOf79yS5DW", "(99) 99999-9992", false, "815600cc-ddb3-4fe2-be36-efc5fb047781", 0, false, new DateTime(2025, 4, 22, 18, 20, 11, 75, DateTimeKind.Local).AddTicks(8934), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52"), new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7") },
                    { new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5"), new Guid("2946f55e-4022-417e-bdfe-62f11709a181") },
                    { new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625"), new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622") },
                    { new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf"), new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6") },
                    { new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909"), new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52"), new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5"), new Guid("2946f55e-4022-417e-bdfe-62f11709a181") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625"), new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf"), new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909"), new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3fbbb80b-1dbb-41d4-b48f-e853b2acfde5"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("4ea84e6f-25f4-4221-85a9-6cc7ee94e625"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c902bc8-4fde-4429-9642-0aff085cf4bf"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cda1fa49-041f-4e9d-bc1f-2ab298218f52"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("de767e59-095d-4fee-87a6-89d7b4dfb909"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("23163eb0-90fd-47af-b83b-c9fc4ee07fb7"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2946f55e-4022-417e-bdfe-62f11709a181"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("506c08a4-78f0-4c1b-ac55-3bfe89604622"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cddb83b5-37bf-48b6-91d1-96a241feb1f6"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dfad1fb2-ff22-4a77-9f22-b47778b23a8b"));

            migrationBuilder.DropColumn(
                name: "ComprovanteUrl",
                table: "Receitas");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Receitas",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3615c2dc-eb32-4e31-a5af-8db08a89e354"), "12c682db-2b9e-425d-8786-c65671e5800a", "Owner", "OWNER" },
                    { new Guid("5ca2dfda-9efd-4a18-b0e6-c6895c819dc7"), "6837e932-e44a-4da8-803e-a5d8f33d1832", "Consultant", "CONSULTANT" },
                    { new Guid("65cad716-abc5-4a76-b99d-2c6e8843dc7b"), "9408a2df-1d2e-43ce-970b-5f17843d5357", "Admin", "ADMIN" },
                    { new Guid("7654ea20-52d4-4612-ba1f-aa8274eb779b"), "31de0b35-9327-4c2a-80dc-dfc0333af18b", "Collaborator", "COLLABORATOR" },
                    { new Guid("f58e5136-55b5-4d24-9ef6-bebd53e9dca3"), "e7424e88-1f55-4d03-a313-e9de203530ea", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("5c342a05-0460-4d74-9af5-9d6d6d81fa12"), 0, "63f97672-2431-4c0c-9a6c-ce100902732c", new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3455), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$EhzY/ZH63p2SyMKLYLVeF.kkVsfNBg/FyFilGr5jzZBqDetczokZm", "(99) 99999-9992", false, "b681d224-740b-4c6a-bb17-dbec40eae47d", 0, false, new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3428), "jane" },
                    { new Guid("5e91068e-29df-40af-b355-fb85020747db"), 0, "31f69298-160e-4d01-9994-a02a8fd58578", new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3475), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$6JB8Cvfh7gU4gaTx05jd2./Oncx5RrYmp.9ntqTslV6O3YMx2AwlO", "(99) 99999-9993", false, "a748d7d1-27d0-413e-8cc5-b791f1fb7f80", 0, false, new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3457), "alice" },
                    { new Guid("66d9ed24-258d-41fe-97df-0c8309eaadc6"), 0, "985eac35-14ca-45cc-bd97-beca27bd9c5f", new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3493), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$ZxOXzZkVxEXB.T/r9Xfr5OjNjjvflJqOBLQS6frTbjy7qF4970p3q", "(99) 99999-9994", false, "53947ed5-10a3-4271-9a0a-c599eec3a5c2", 0, false, new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3478), "bob" },
                    { new Guid("8c040141-bb0c-4a7f-87f0-2d00bd592f03"), 0, "506190d0-ed91-4123-b92a-2e0b10d86b8e", new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3172), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$cZqs.orLWIdtHhqr.J5T4uR0nlnLC5CYCmEJ4DNGnkxM9aIas3pwi", "(99) 99999-9991", false, "74a8be1f-d310-4903-a6a8-4452b0bbf112", 0, false, new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(1341), "john" },
                    { new Guid("fbdf5d81-1ab1-431f-87f9-c1e275a31e49"), 0, "5720c65d-9ad9-4926-b7a8-7a26576293ae", new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3498), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$UXPf9OH1N21zIqK0Cte4QeRs2vz8OzMt3skTiqx3gdfFgWim1LGGy", "(99) 99999-9995", false, "33333b9d-3a25-470f-a93a-503592d35b41", 0, false, new DateTime(2025, 4, 14, 19, 26, 32, 121, DateTimeKind.Local).AddTicks(3494), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3615c2dc-eb32-4e31-a5af-8db08a89e354"), new Guid("5c342a05-0460-4d74-9af5-9d6d6d81fa12") },
                    { new Guid("5ca2dfda-9efd-4a18-b0e6-c6895c819dc7"), new Guid("5e91068e-29df-40af-b355-fb85020747db") },
                    { new Guid("f58e5136-55b5-4d24-9ef6-bebd53e9dca3"), new Guid("66d9ed24-258d-41fe-97df-0c8309eaadc6") },
                    { new Guid("65cad716-abc5-4a76-b99d-2c6e8843dc7b"), new Guid("8c040141-bb0c-4a7f-87f0-2d00bd592f03") },
                    { new Guid("7654ea20-52d4-4612-ba1f-aa8274eb779b"), new Guid("fbdf5d81-1ab1-431f-87f9-c1e275a31e49") }
                });
        }
    }
}
