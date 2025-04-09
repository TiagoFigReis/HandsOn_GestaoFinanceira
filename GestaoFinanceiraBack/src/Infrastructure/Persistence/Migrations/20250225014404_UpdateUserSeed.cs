using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07ddff2c-3084-4b5d-9f65-bc1f88731dc3"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3d6d8139-b78a-4e6c-a74c-169919a91177"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9aac2304-c32a-49d0-872e-40c1f8686271"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b203bbda-5084-46cf-ac24-aa47cbd25577"), new Guid("06fc0a87-f77b-4159-9847-570f05c41a6f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("344d5ff8-b456-40e1-9cca-23ed537a9a83"), new Guid("39a8c686-7753-4d94-bcf7-dbf049d61d9c") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("344d5ff8-b456-40e1-9cca-23ed537a9a83"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b203bbda-5084-46cf-ac24-aa47cbd25577"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("06fc0a87-f77b-4159-9847-570f05c41a6f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("39a8c686-7753-4d94-bcf7-dbf049d61d9c"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("040803d1-f4b7-436d-a796-6a1a49d22b92"), "9bb3c6d8-91ec-4108-8842-4bf03dcf27d2", "Manager", "MANAGER" },
                    { new Guid("165f15b2-6357-4b20-8250-ed8f087c7469"), "da90f0a2-7628-43a7-af9d-1f4874f899f8", "Owner", "OWNER" },
                    { new Guid("5dcb1bcc-8561-4541-ae07-79fe2e3dd21f"), "d0a91a7d-473f-4d0e-b032-c4285c9fdc8c", "Collaborator", "COLLABORATOR" },
                    { new Guid("91b5796d-66fd-40cc-82b2-17ec5de7876b"), "dffd821d-0fa8-4ad2-82e0-2f61c5cbe832", "Consultant", "CONSULTANT" },
                    { new Guid("9331d77f-4d15-42de-8136-44b996902f62"), "52582de9-d463-4e0b-8cc3-916f551cf6bb", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("66d3d671-5670-48a9-ac52-61db1a4cc575"), 0, "b88d9630-6490-4f15-940a-f44b059fa495", new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(167), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$DcX.LtVaAVgq8aoJGicJQ.AjxG4BCXqhEhG2Y/KkJ76QsJ2oY0hGK", "+5535922222222", false, "df7854a0-21eb-4f13-a2d9-69a5ffcc2cfa", 0, false, new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(164), "alice" },
                    { new Guid("68f0303a-94cf-4f9b-a1ff-85bc75f48aa9"), 0, "e7ef6b22-32c9-45e6-976d-d8fae9099bca", new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(178), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$7KEA6E.2ESquv.J1obVie.XQ7emN/X9p09JBbwwuAr22FX3mY7wgO", "+5535933333333", false, "29e0f3a8-8a11-45b2-80fc-6a8a18a335c1", 0, false, new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(168), "bob" },
                    { new Guid("7b4f2b03-a795-4d3b-9191-0de5b668441f"), 0, "30320725-3fa4-401d-b67d-943a22975db1", new DateTime(2025, 2, 24, 22, 44, 2, 550, DateTimeKind.Local).AddTicks(9671), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$vmJJG8LAOVUvn7VBiyAyq.PZTkU4nJHHSDSv3qFW/yHbqcDSXqP6G", "+5535900000000", false, "03ac9d21-6508-441f-8df8-8b88a2eea046", 0, false, new DateTime(2025, 2, 24, 22, 44, 2, 550, DateTimeKind.Local).AddTicks(7070), "john" },
                    { new Guid("e998504d-8b41-45b2-9991-1b83d49834fc"), 0, "19ab7ccf-ed17-4aa0-9277-7ae523d6600b", new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(162), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$0Aazna7GaJBt9xib/H20huB9X2ZDNPrI45S8LkH5gGx0B../UGA12", "+5535911111111", false, "b6eaf6c7-fffe-44f9-a8a1-6023362eceb6", 0, false, new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(137), "jane" },
                    { new Guid("f5a86e69-6dd3-430b-af47-71532a31df88"), 0, "a20a100c-8931-49d7-bbe8-9dd2c5df2a59", new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(183), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$NL.PXsi62cVEpTdOgD6zfuLO8QyUzjLlsqF.A0MovTjix5/1EUzve", "+5535944444444", false, "50dc0846-eafe-49a5-9739-119ee159a04a", 0, false, new DateTime(2025, 2, 24, 22, 44, 2, 551, DateTimeKind.Local).AddTicks(179), "charlie" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("91b5796d-66fd-40cc-82b2-17ec5de7876b"), new Guid("66d3d671-5670-48a9-ac52-61db1a4cc575") },
                    { new Guid("040803d1-f4b7-436d-a796-6a1a49d22b92"), new Guid("68f0303a-94cf-4f9b-a1ff-85bc75f48aa9") },
                    { new Guid("9331d77f-4d15-42de-8136-44b996902f62"), new Guid("7b4f2b03-a795-4d3b-9191-0de5b668441f") },
                    { new Guid("165f15b2-6357-4b20-8250-ed8f087c7469"), new Guid("e998504d-8b41-45b2-9991-1b83d49834fc") },
                    { new Guid("5dcb1bcc-8561-4541-ae07-79fe2e3dd21f"), new Guid("f5a86e69-6dd3-430b-af47-71532a31df88") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("91b5796d-66fd-40cc-82b2-17ec5de7876b"), new Guid("66d3d671-5670-48a9-ac52-61db1a4cc575") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("040803d1-f4b7-436d-a796-6a1a49d22b92"), new Guid("68f0303a-94cf-4f9b-a1ff-85bc75f48aa9") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9331d77f-4d15-42de-8136-44b996902f62"), new Guid("7b4f2b03-a795-4d3b-9191-0de5b668441f") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("165f15b2-6357-4b20-8250-ed8f087c7469"), new Guid("e998504d-8b41-45b2-9991-1b83d49834fc") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5dcb1bcc-8561-4541-ae07-79fe2e3dd21f"), new Guid("f5a86e69-6dd3-430b-af47-71532a31df88") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("040803d1-f4b7-436d-a796-6a1a49d22b92"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("165f15b2-6357-4b20-8250-ed8f087c7469"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5dcb1bcc-8561-4541-ae07-79fe2e3dd21f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("91b5796d-66fd-40cc-82b2-17ec5de7876b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9331d77f-4d15-42de-8136-44b996902f62"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("66d3d671-5670-48a9-ac52-61db1a4cc575"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("68f0303a-94cf-4f9b-a1ff-85bc75f48aa9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7b4f2b03-a795-4d3b-9191-0de5b668441f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e998504d-8b41-45b2-9991-1b83d49834fc"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f5a86e69-6dd3-430b-af47-71532a31df88"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("07ddff2c-3084-4b5d-9f65-bc1f88731dc3"), "75fdceba-8d71-4313-ae76-480dec654076", "Manager", "MANAGER" },
                    { new Guid("344d5ff8-b456-40e1-9cca-23ed537a9a83"), "c21952b7-0fdf-4e1d-afc7-4a764120241b", "Owner", "OWNER" },
                    { new Guid("3d6d8139-b78a-4e6c-a74c-169919a91177"), "841eb4ef-0a71-4f04-a33b-72d46e844137", "Collaborator", "COLLABORATOR" },
                    { new Guid("9aac2304-c32a-49d0-872e-40c1f8686271"), "17237211-303d-4c04-87ae-12c825497d7b", "Consultant", "CONSULTANT" },
                    { new Guid("b203bbda-5084-46cf-ac24-aa47cbd25577"), "c6101b89-954c-4cc5-a1e8-37507e2e429d", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("06fc0a87-f77b-4159-9847-570f05c41a6f"), 0, "c23b702e-0cdd-4110-b432-7e3832e6e326", new DateTime(2025, 2, 24, 22, 19, 52, 399, DateTimeKind.Local).AddTicks(1924), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$IWfIs85IC1FPDPWjHTAAOOcSobQPq56QKDiyWBG3g.d84AyQjLWk2", "+5535900000000", false, "22f1b56c-1d8b-45bb-9617-a2bd99a527de", 0, false, new DateTime(2025, 2, 24, 22, 19, 52, 398, DateTimeKind.Local).AddTicks(9663), "john" },
                    { new Guid("39a8c686-7753-4d94-bcf7-dbf049d61d9c"), 0, "4377d097-ae05-46c4-87b4-afd738c27920", new DateTime(2025, 2, 24, 22, 19, 52, 399, DateTimeKind.Local).AddTicks(2266), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$W6dmGNxVLVENRovmJgElou.TEnhLtsOeI2MAO9U1//07x6XLPYg6W", "+5535911111111", false, "69be944f-d01f-417a-9d40-d125ff48275b", 0, false, new DateTime(2025, 2, 24, 22, 19, 52, 399, DateTimeKind.Local).AddTicks(2247), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b203bbda-5084-46cf-ac24-aa47cbd25577"), new Guid("06fc0a87-f77b-4159-9847-570f05c41a6f") },
                    { new Guid("344d5ff8-b456-40e1-9cca-23ed537a9a83"), new Guid("39a8c686-7753-4d94-bcf7-dbf049d61d9c") }
                });
        }
    }
}
