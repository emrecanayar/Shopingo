using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CompanyAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f76e29a9-f7c0-491e-9668-c5459c205806"));

            migrationBuilder.CreateTable(
                name: "CompanyAddresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddressTextKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WorkingDay = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyAddresses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 19, 20, 40, 54, 860, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("6c948d64-3766-496a-b50f-f5063354d814"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 174, 197, 78, 115, 193, 156, 46, 134, 225, 132, 130, 242, 118, 241, 152, 92, 177, 139, 111, 61, 17, 47, 84, 98, 53, 145, 166, 85, 225, 1, 22, 86, 133, 113, 38, 149, 94, 119, 115, 55, 141, 228, 252, 129, 89, 193, 4, 102, 81, 92, 11, 219, 178, 89, 63, 177, 172, 20, 138, 212, 10, 56, 31, 29 }, new byte[] { 22, 219, 118, 131, 59, 81, 7, 147, 116, 67, 56, 195, 83, 237, 90, 15, 10, 178, 117, 32, 78, 178, 167, 184, 87, 156, 242, 206, 123, 104, 132, 248, 38, 210, 130, 14, 103, 18, 66, 160, 245, 251, 216, 18, 114, 47, 111, 42, 162, 21, 24, 10, 202, 177, 238, 189, 169, 64, 177, 92, 26, 34, 152, 35, 156, 241, 253, 68, 58, 54, 239, 49, 197, 250, 72, 113, 164, 28, 25, 139, 206, 7, 115, 147, 68, 170, 148, 82, 241, 214, 8, 42, 153, 140, 212, 18, 38, 65, 42, 156, 4, 252, 248, 186, 190, 1, 207, 212, 254, 25, 163, 210, 146, 238, 87, 167, 76, 108, 137, 230, 110, 161, 226, 255, 109, 184, 82, 149 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyAddresses");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6c948d64-3766-496a-b50f-f5063354d814"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 13, 19, 5, 22, 867, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("f76e29a9-f7c0-491e-9668-c5459c205806"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 16, 254, 161, 254, 5, 104, 116, 32, 51, 134, 75, 23, 147, 34, 155, 219, 209, 150, 212, 166, 112, 37, 211, 129, 87, 89, 88, 141, 179, 46, 29, 97, 239, 7, 42, 215, 223, 242, 223, 93, 58, 157, 228, 69, 251, 129, 49, 29, 230, 19, 189, 39, 226, 140, 42, 202, 238, 49, 194, 9, 28, 105, 80 }, new byte[] { 18, 93, 214, 59, 2, 18, 1, 45, 138, 50, 241, 19, 191, 2, 153, 172, 44, 151, 148, 104, 137, 90, 81, 212, 218, 238, 24, 10, 217, 168, 228, 78, 203, 198, 26, 244, 108, 48, 9, 91, 251, 111, 168, 188, 248, 209, 122, 125, 20, 106, 49, 139, 248, 10, 83, 88, 125, 160, 8, 37, 78, 81, 253, 89, 47, 220, 250, 16, 193, 195, 54, 190, 0, 155, 90, 11, 246, 180, 50, 156, 82, 225, 42, 193, 113, 112, 192, 29, 154, 185, 48, 30, 160, 253, 147, 210, 147, 196, 28, 57, 173, 164, 154, 138, 48, 128, 60, 143, 251, 100, 114, 239, 248, 210, 64, 134, 157, 124, 96, 170, 215, 247, 198, 156, 175, 137, 181, 0 } });
        }
    }
}
