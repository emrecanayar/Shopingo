using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6c948d64-3766-496a-b50f-f5063354d814"));

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "CompanyAddresses",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "CompanyAddresses",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddressTextKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    WorkingDay = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Latitude = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 25, 17, 41, 6, 276, DateTimeKind.Local).AddTicks(5027));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("0a12ac55-cc7b-441a-8106-f2510957de1f"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 23, 196, 50, 81, 24, 61, 189, 148, 119, 207, 155, 191, 197, 248, 229, 55, 79, 150, 118, 234, 141, 249, 218, 164, 166, 233, 166, 132, 186, 41, 59, 116, 171, 26, 9, 239, 147, 188, 249, 46, 238, 181, 4, 195, 160, 3, 84, 231, 45, 227, 203, 52, 214, 122, 190, 72, 134, 83, 32, 121, 202, 219, 97, 232 }, new byte[] { 173, 45, 156, 184, 219, 131, 215, 175, 50, 69, 90, 240, 143, 248, 19, 34, 118, 204, 163, 247, 200, 178, 98, 144, 8, 206, 196, 227, 222, 195, 38, 84, 199, 152, 89, 206, 102, 98, 254, 5, 33, 41, 10, 128, 24, 86, 190, 114, 55, 125, 237, 215, 96, 193, 60, 56, 16, 228, 7, 143, 183, 215, 74, 116, 60, 237, 45, 206, 14, 157, 143, 114, 251, 149, 93, 74, 79, 179, 7, 108, 129, 239, 75, 194, 119, 237, 239, 116, 15, 141, 204, 170, 132, 83, 116, 71, 58, 90, 210, 178, 22, 215, 84, 39, 174, 11, 180, 80, 98, 73, 22, 19, 107, 229, 82, 156, 104, 87, 101, 82, 246, 64, 172, 100, 218, 9, 74, 157 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0a12ac55-cc7b-441a-8106-f2510957de1f"));

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "CompanyAddresses");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "CompanyAddresses");

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
    }
}
