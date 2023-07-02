using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Country : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1f7db4d9-d4ec-4d4b-b18c-6e995a6aa5c2"));

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Iso = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Iso3 = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    NumCode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    PhoneCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 2, 33, 3, 421, DateTimeKind.Local).AddTicks(3296));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("4478c528-8d45-41d7-83bc-af8daf93232b"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 90, 72, 43, 194, 91, 142, 55, 70, 161, 154, 190, 51, 219, 173, 193, 209, 178, 248, 211, 152, 221, 110, 235, 75, 195, 215, 229, 129, 10, 105, 128, 66, 98, 214, 197, 74, 59, 124, 40, 188, 124, 228, 178, 244, 95, 151, 131, 192, 181, 88, 194, 175, 138, 248, 178, 18, 188, 162, 78, 192, 159, 127, 197, 182 }, new byte[] { 44, 190, 165, 186, 108, 87, 8, 58, 64, 13, 121, 158, 22, 17, 195, 164, 255, 22, 186, 96, 51, 112, 123, 216, 156, 43, 58, 31, 35, 225, 19, 196, 225, 70, 38, 230, 228, 106, 169, 21, 24, 122, 239, 70, 229, 94, 49, 132, 224, 134, 253, 189, 253, 149, 160, 215, 182, 95, 252, 136, 95, 2, 2, 23, 8, 12, 120, 224, 247, 4, 42, 100, 176, 147, 218, 134, 176, 164, 217, 15, 23, 118, 96, 220, 178, 57, 140, 194, 212, 144, 95, 254, 10, 99, 42, 34, 15, 55, 228, 104, 252, 81, 12, 133, 56, 156, 169, 74, 176, 195, 208, 4, 149, 100, 140, 244, 32, 106, 96, 121, 48, 31, 126, 156, 37, 124, 237, 62 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4478c528-8d45-41d7-83bc-af8daf93232b"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 2, 2, 19, 172, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("1f7db4d9-d4ec-4d4b-b18c-6e995a6aa5c2"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 129, 100, 188, 163, 170, 94, 252, 146, 47, 220, 155, 158, 160, 164, 43, 218, 29, 150, 196, 247, 82, 164, 56, 153, 187, 230, 166, 81, 111, 69, 17, 199, 174, 81, 76, 159, 200, 216, 201, 36, 146, 186, 174, 131, 176, 154, 13, 80, 183, 200, 155, 207, 54, 70, 137, 25, 219, 253, 251, 156, 5, 188, 35, 57 }, new byte[] { 23, 7, 27, 74, 28, 244, 45, 237, 63, 202, 45, 73, 76, 186, 72, 150, 10, 38, 69, 249, 254, 61, 84, 74, 164, 114, 2, 193, 137, 69, 254, 208, 174, 110, 197, 9, 121, 18, 252, 162, 142, 210, 82, 58, 56, 199, 41, 18, 209, 160, 89, 184, 34, 254, 177, 154, 40, 125, 60, 128, 33, 49, 15, 120, 148, 44, 182, 214, 155, 21, 43, 177, 232, 78, 230, 184, 153, 96, 27, 35, 3, 232, 200, 135, 203, 178, 61, 53, 98, 85, 46, 118, 43, 181, 29, 166, 206, 193, 8, 194, 35, 29, 255, 163, 198, 136, 28, 243, 162, 144, 43, 178, 199, 23, 87, 242, 35, 149, 106, 86, 164, 238, 98, 223, 252, 89, 181, 100 } });
        }
    }
}
