using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("92ef2a00-66d3-41bb-94fc-8b193b6ec13b"));

            migrationBuilder.CreateTable(
                name: "ContactInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressTextKey = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkingDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfo", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 29, 23, 18, 48, 760, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("17335687-bdcc-4b95-a0e0-a0496855fb62"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 117, 158, 25, 159, 222, 17, 8, 201, 75, 12, 79, 145, 63, 119, 204, 0, 168, 157, 94, 71, 47, 103, 21, 194, 43, 228, 212, 227, 192, 206, 129, 86, 192, 146, 9, 116, 231, 88, 8, 166, 87, 137, 1, 160, 110, 123, 130, 144, 38, 71, 175, 40, 76, 144, 207, 76, 45, 239, 188, 144, 163, 88, 213, 17 }, new byte[] { 241, 244, 191, 199, 232, 61, 68, 52, 163, 136, 234, 15, 152, 33, 206, 86, 106, 162, 122, 230, 22, 57, 33, 101, 80, 176, 205, 92, 52, 167, 176, 105, 119, 221, 210, 132, 249, 105, 51, 160, 19, 217, 184, 158, 109, 38, 234, 129, 31, 115, 122, 3, 66, 114, 199, 252, 0, 254, 12, 225, 180, 83, 153, 166, 113, 64, 99, 159, 224, 158, 81, 12, 157, 96, 236, 6, 77, 235, 15, 2, 186, 129, 75, 239, 182, 156, 188, 12, 12, 167, 94, 51, 249, 69, 205, 91, 177, 108, 116, 247, 186, 38, 116, 66, 23, 174, 189, 220, 176, 159, 14, 41, 61, 251, 187, 213, 85, 232, 175, 9, 221, 217, 250, 75, 165, 200, 201, 149 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfo");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("17335687-bdcc-4b95-a0e0-a0496855fb62"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 17, 29, 3, 431, DateTimeKind.Local).AddTicks(105));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("92ef2a00-66d3-41bb-94fc-8b193b6ec13b"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 144, 209, 93, 243, 82, 163, 22, 169, 123, 77, 110, 232, 204, 73, 151, 158, 88, 225, 80, 162, 152, 169, 63, 26, 159, 42, 108, 39, 179, 38, 97, 43, 83, 143, 20, 195, 164, 35, 212, 15, 165, 150, 154, 227, 186, 174, 88, 166, 22, 99, 227, 159, 95, 83, 63, 106, 85, 179, 212, 11, 255, 4, 24 }, new byte[] { 87, 97, 107, 99, 4, 80, 13, 58, 99, 75, 175, 79, 203, 187, 129, 182, 188, 37, 1, 106, 58, 56, 128, 62, 14, 56, 41, 14, 208, 238, 128, 114, 155, 117, 21, 186, 193, 116, 158, 55, 14, 192, 61, 9, 198, 102, 196, 158, 89, 200, 227, 155, 107, 167, 236, 108, 23, 110, 67, 132, 255, 196, 7, 22, 249, 149, 216, 127, 141, 156, 84, 121, 132, 78, 145, 222, 198, 236, 168, 118, 184, 8, 52, 247, 180, 182, 95, 81, 243, 179, 94, 80, 87, 102, 225, 252, 206, 0, 56, 83, 155, 97, 247, 206, 131, 122, 119, 49, 71, 76, 73, 225, 94, 220, 169, 56, 33, 34, 217, 9, 202, 246, 43, 35, 61, 211, 127, 231 } });
        }
    }
}
