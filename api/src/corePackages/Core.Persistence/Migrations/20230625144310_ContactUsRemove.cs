using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactUsRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0a12ac55-cc7b-441a-8106-f2510957de1f"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 25, 17, 43, 9, 900, DateTimeKind.Local).AddTicks(7099));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("7a74b928-22a2-4a8b-855d-7ee9e0323084"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 188, 64, 55, 190, 188, 101, 16, 153, 147, 91, 188, 24, 86, 63, 174, 147, 2, 16, 228, 98, 97, 203, 9, 83, 154, 26, 21, 123, 78, 19, 198, 2, 35, 125, 176, 178, 121, 37, 7, 204, 95, 219, 251, 15, 239, 145, 145, 66, 21, 126, 146, 137, 168, 40, 146, 14, 91, 245, 25, 223, 45, 238, 141, 37 }, new byte[] { 129, 120, 3, 210, 84, 158, 181, 97, 90, 170, 72, 3, 222, 55, 133, 114, 170, 165, 209, 7, 183, 23, 153, 2, 90, 254, 10, 103, 193, 22, 50, 106, 167, 161, 196, 165, 217, 103, 34, 231, 241, 102, 108, 236, 91, 165, 144, 2, 207, 34, 53, 190, 247, 214, 167, 150, 53, 253, 117, 132, 139, 215, 185, 239, 63, 159, 126, 58, 55, 118, 32, 247, 55, 140, 201, 168, 109, 120, 206, 13, 15, 190, 58, 215, 77, 236, 124, 97, 84, 99, 61, 115, 2, 171, 85, 137, 0, 83, 121, 226, 96, 126, 48, 58, 251, 159, 62, 54, 96, 58, 41, 203, 112, 70, 226, 211, 230, 158, 29, 237, 92, 250, 47, 69, 18, 36, 114, 43 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7a74b928-22a2-4a8b-855d-7ee9e0323084"));

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    AddressTextKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Latitude = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Longitude = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    WorkingDay = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false)
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
    }
}
