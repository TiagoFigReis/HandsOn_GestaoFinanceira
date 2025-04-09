using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserPhoneAndUpdateRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d68d78d4-35af-432d-87f2-230e10cfe1ca"), new Guid("759889e6-ecca-46a0-b367-65a943a9d327") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6bfabb3c-8560-4777-a74f-0e2e59f3f97f"), new Guid("ba0c22da-37b8-4060-96fa-7feacf876741") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6bfabb3c-8560-4777-a74f-0e2e59f3f97f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d68d78d4-35af-432d-87f2-230e10cfe1ca"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("759889e6-ecca-46a0-b367-65a943a9d327"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ba0c22da-37b8-4060-96fa-7feacf876741"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("6bfabb3c-8560-4777-a74f-0e2e59f3f97f"), "236622b5-705b-4303-8d88-765f73e0eb38", "Staff", "STAFF" },
                    { new Guid("d68d78d4-35af-432d-87f2-230e10cfe1ca"), "b95d4d57-5757-4a80-a9c3-38f93e642711", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedAt", "UserName" },
                values: new object[,]
                {
                    { new Guid("759889e6-ecca-46a0-b367-65a943a9d327"), 0, "ca9d45d3-ab36-4756-a6ea-ae5e11f1a9d7", new DateTime(2025, 2, 21, 12, 52, 58, 887, DateTimeKind.Local).AddTicks(6378), "example1@gmail.com", false, "John", "Doe", false, null, "EXAMPLE1@GMAIL.COM", "JOHN", "$2a$11$yw5rp.nRwOxTzFh5lo.Qw.FrYyySN3yAO6LOFt3VCInviHODLdprO", null, false, "f7688574-bc27-42fe-b1ea-3df6f81f38ee", 0, false, new DateTime(2025, 2, 21, 12, 52, 58, 887, DateTimeKind.Local).AddTicks(4022), "john" },
                    { new Guid("ba0c22da-37b8-4060-96fa-7feacf876741"), 0, "d55c1c98-dff8-48b8-a4a2-63a8f265a3a7", new DateTime(2025, 2, 21, 12, 52, 58, 887, DateTimeKind.Local).AddTicks(6817), "example2@gmail.com", false, "Jane", "Doe", false, null, "EXAMPLE2@GMAIL.COM", "JANE", "$2a$11$CvrTuJZGioQlpfpdc4tuEOUG4YOdG1eKMHMr94UNA0d1tgyAm0w4C", null, false, "96f38076-da1e-4407-9d28-c2118c864f01", 0, false, new DateTime(2025, 2, 21, 12, 52, 58, 887, DateTimeKind.Local).AddTicks(6779), "jane" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d68d78d4-35af-432d-87f2-230e10cfe1ca"), new Guid("759889e6-ecca-46a0-b367-65a943a9d327") },
                    { new Guid("6bfabb3c-8560-4777-a74f-0e2e59f3f97f"), new Guid("ba0c22da-37b8-4060-96fa-7feacf876741") }
                });
        }
    }
}
