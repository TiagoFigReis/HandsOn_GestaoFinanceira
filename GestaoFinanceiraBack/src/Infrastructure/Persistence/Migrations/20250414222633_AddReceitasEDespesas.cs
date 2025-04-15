using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddReceitasEDespesas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Categoria = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Fonte = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Data = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Receitas");

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
    }
}
