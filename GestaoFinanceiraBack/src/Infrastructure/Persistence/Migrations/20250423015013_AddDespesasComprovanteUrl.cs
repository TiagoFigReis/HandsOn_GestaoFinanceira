using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddDespesasComprovanteUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "ComprovanteUrl",
                table: "Despesas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6cab802d-b13c-434f-b595-247f151d6cef"), "e983cfd9-ec55-40c3-ab3d-24574931f000", "Consultant", "CONSULTANT" },
                    { new Guid("a336e066-1528-4525-8a16-980a839e25f2"), "94a5bb3f-4b87-4ad0-b025-affbf3f2769a", "Manager", "MANAGER" },
                    { new Guid("c487128f-c41b-4514-8bc9-55f83fbfd897"), "1a2e9db5-0b29-4130-9763-44c5548168d2", "Owner", "OWNER" },
                    { new Guid("f2307446-8e70-4aa8-b14f-fd6b2d6ceaa4"), "f3bc9be2-cc44-4572-8ca9-a8cc7f64ae9b", "Admin", "ADMIN" },
                    { new Guid("f2365769-84ed-4cfa-85db-fee83ed565db"), "4f36348a-259f-428a-8551-292bf541480a", "Collaborator", "COLLABORATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("2b122a53-6f64-4b8e-8d9e-b0b3d6a968eb"), 0, "9c43874d-7534-412d-9f48-5c634cd6e739", new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2649), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$Xtl/7Zo2tD6vQq5GUVMGpefDshfgbuofhuHqMdnAkOORV00mhe4yW", "(99) 99999-9992", false, "bab08c52-f43b-4b28-b01a-bdfd92beeb71", 0, false, new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2632), "jane" },
                    { new Guid("30089dfd-b102-4011-80b6-57c3cd4a8fd9"), 0, "4fa387bf-079a-4f55-9025-5586b7dbbe54", new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2391), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$KBV22AVRQYGhqMWfpA2SRuisLRYdSkrCwxsFoRbX6pGQSAcWpxiW2", "(99) 99999-9991", false, "d3b9f14e-044e-41f9-bd25-ad5781e2b190", 0, false, new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(608), "john" },
                    { new Guid("751eb002-3658-458f-91ba-16ea37547cc5"), 0, "eaee63f6-d4b4-4856-b0ea-f5264b4d1c14", new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2654), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$RM4VpQQrROvTPS737uvgB.1rtoL4EyrtxSatjvoFP7bAjxf28eDb2", "(99) 99999-9993", false, "04a3ec84-9747-480f-997f-d4e2e6ec6b19", 0, false, new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2651), "alice" },
                    { new Guid("ace8c3cf-8e26-408d-9b46-8e0e1d480aaa"), 0, "54f6772b-b787-4dce-a25c-19fb5be0d3f8", new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2662), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$6s.crCBaZ9TW3crvlq1Wh.5K.2qkgnxJLZG8AlR23kE8nKQWSTDaa", "(99) 99999-9994", false, "aae7b438-3e4a-44df-8937-7ad30ef210f7", 0, false, new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2654), "bob" },
                    { new Guid("d4a7a6f8-563d-4551-b091-f238122d5f1f"), 0, "be3d4836-3c15-4342-ad59-e4216ba45ad7", new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2665), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$tq6I8ZPnydDvjkk3Hexsa.ms7WR1aKyvaLm1NxURfNwf1XmRa.SwO", "(99) 99999-9995", false, "f334d308-25c7-4e3b-aab4-7c13ee45bcc4", 0, false, new DateTime(2025, 4, 22, 22, 50, 12, 25, DateTimeKind.Local).AddTicks(2662), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c487128f-c41b-4514-8bc9-55f83fbfd897"), new Guid("2b122a53-6f64-4b8e-8d9e-b0b3d6a968eb") },
                    { new Guid("f2307446-8e70-4aa8-b14f-fd6b2d6ceaa4"), new Guid("30089dfd-b102-4011-80b6-57c3cd4a8fd9") },
                    { new Guid("6cab802d-b13c-434f-b595-247f151d6cef"), new Guid("751eb002-3658-458f-91ba-16ea37547cc5") },
                    { new Guid("a336e066-1528-4525-8a16-980a839e25f2"), new Guid("ace8c3cf-8e26-408d-9b46-8e0e1d480aaa") },
                    { new Guid("f2365769-84ed-4cfa-85db-fee83ed565db"), new Guid("d4a7a6f8-563d-4551-b091-f238122d5f1f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("c487128f-c41b-4514-8bc9-55f83fbfd897"), new Guid("2b122a53-6f64-4b8e-8d9e-b0b3d6a968eb") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f2307446-8e70-4aa8-b14f-fd6b2d6ceaa4"), new Guid("30089dfd-b102-4011-80b6-57c3cd4a8fd9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6cab802d-b13c-434f-b595-247f151d6cef"), new Guid("751eb002-3658-458f-91ba-16ea37547cc5") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a336e066-1528-4525-8a16-980a839e25f2"), new Guid("ace8c3cf-8e26-408d-9b46-8e0e1d480aaa") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f2365769-84ed-4cfa-85db-fee83ed565db"), new Guid("d4a7a6f8-563d-4551-b091-f238122d5f1f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cab802d-b13c-434f-b595-247f151d6cef"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a336e066-1528-4525-8a16-980a839e25f2"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c487128f-c41b-4514-8bc9-55f83fbfd897"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2307446-8e70-4aa8-b14f-fd6b2d6ceaa4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f2365769-84ed-4cfa-85db-fee83ed565db"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2b122a53-6f64-4b8e-8d9e-b0b3d6a968eb"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("30089dfd-b102-4011-80b6-57c3cd4a8fd9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("751eb002-3658-458f-91ba-16ea37547cc5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ace8c3cf-8e26-408d-9b46-8e0e1d480aaa"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d4a7a6f8-563d-4551-b091-f238122d5f1f"));

            migrationBuilder.DropColumn(
                name: "ComprovanteUrl",
                table: "Despesas");

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
    }
}
