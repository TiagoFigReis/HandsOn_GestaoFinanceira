using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserPhoneSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), "aa23e890-96a6-4557-82a2-eae8ebade3cb", "Consultant", "CONSULTANT" },
                    { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), "a06d95f3-9c52-4a39-ad2a-4085ec83e764", "Manager", "MANAGER" },
                    { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), "3d58d68b-3852-40d9-9c40-e0f0565ec68e", "Collaborator", "COLLABORATOR" },
                    { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), "dbfcf47c-59be-4b08-a9ca-fbbdb18bd6d9", "Owner", "OWNER" },
                    { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), "431e73e6-5238-4024-8141-5355c5e91d52", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("3d333144-c00a-490f-970c-aa995da67100"), 0, "db52f37f-924e-42af-ab5f-1bca57412bbd", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2569), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$.fY72scmAdUZ2leBi5.O/Op2XbpJnFMh2n.LdeoY246Pa6Rt/uDO2", "(99) 99999-9991", false, "7841ebd5-6212-48f6-a6b2-aa472f01ccc2", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 116, DateTimeKind.Local).AddTicks(9351), "john" },
                    { new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"), 0, "5fe5ed19-8167-4b69-b38c-9d8f6a076012", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3065), "example3@gmail.com", false, "Alice", "Anderson", false, null, "EXAMPLE3@GMAIL.COM", "ALICE", "$2a$11$/e8R1TfwYfT6XsB7Zddmo.KynrAEY.TIrbpjigDGW5FQgvyBM2ptS", "(99) 99999-9993", false, "546d828d-a70e-4012-a6e9-8beac0552599", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3056), "alice" },
                    { new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"), 0, "650cce00-1734-4585-bc30-a25474e282a8", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3087), "example5@gmail.com", false, "Charlie", "Smith", false, null, "EXAMPLE5@GMAIL.COM", "CHARLIE", "$2a$11$B/ngxiWj0FCSa/osLPYBAez8k6ntJjUhNbyAjGcGFUNmr0ak.W8Vm", "(99) 99999-9995", false, "553b8b44-52e4-4f09-99f8-d225f03d3433", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3079), "charlie" },
                    { new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"), 0, "020c0d83-b132-45e0-bc26-a5b64941d899", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3075), "example4@gmail.com", false, "Bob", "Anderson", false, null, "EXAMPLE4@GMAIL.COM", "BOB", "$2a$11$27zZAGL4qvzhThokBox8ieggp7l8UGPEu9YpM/4giov2rM33bLA8a", "(99) 99999-9994", false, "b89df511-3e8d-404a-9e1e-e7f7ce66d508", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3067), "bob" },
                    { new Guid("9b133a03-3800-4248-b129-4d74a60d8395"), 0, "3b863f86-88cf-4e75-b081-2ef902a1dadd", new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(3052), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$ioHWq/EohvquKoiZlGW2SeUthdzBRHxRavz64jPADk2wAj5cTgv9O", "(99) 99999-9992", false, "8847620b-0885-4b56-8a87-68e9f0548727", 0, false, new DateTime(2025, 3, 14, 13, 58, 51, 117, DateTimeKind.Local).AddTicks(2994), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), new Guid("3d333144-c00a-490f-970c-aa995da67100") },
                    { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8") },
                    { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31") },
                    { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850") },
                    { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), new Guid("9b133a03-3800-4248-b129-4d74a60d8395") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"), new Guid("3d333144-c00a-490f-970c-aa995da67100") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"), new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"), new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"), new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"), new Guid("9b133a03-3800-4248-b129-4d74a60d8395") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("001496cf-cac1-4343-815c-c929c4b75dc8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3f2027ec-7d81-4bdb-8e2e-b751b69ce66f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("95fafd63-7c4a-4fc4-89ba-bcc8e6f88dc9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("aad68f57-f451-4c3f-9d11-3c8f751e0691"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bebd57ca-374a-4b9a-a4eb-e4666386b606"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("3d333144-c00a-490f-970c-aa995da67100"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("51c53d94-1842-47eb-b73c-75b89ec20ff8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6171d456-d6c7-4914-8b4f-6e76b3782d31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("875a2dc0-8078-4501-8089-a01a9bcfc850"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("9b133a03-3800-4248-b129-4d74a60d8395"));

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
    }
}
