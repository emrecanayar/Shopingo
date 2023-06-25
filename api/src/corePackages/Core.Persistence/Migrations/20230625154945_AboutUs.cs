using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AboutUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("7a74b928-22a2-4a8b-855d-7ee9e0323084"));

            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 25, 18, 49, 45, 407, DateTimeKind.Local).AddTicks(8630));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("aec27c4f-a499-42b6-b1e1-8c688760a951"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 157, 44, 2, 59, 147, 88, 32, 115, 173, 197, 162, 44, 115, 16, 102, 162, 77, 132, 36, 2, 105, 113, 156, 52, 44, 94, 52, 216, 222, 254, 60, 237, 222, 154, 102, 226, 149, 133, 205, 212, 220, 238, 178, 123, 222, 225, 121, 240, 199, 155, 42, 207, 32, 67, 24, 14, 178, 157, 33, 233, 228, 88, 146, 68 }, new byte[] { 221, 160, 15, 78, 94, 231, 65, 2, 57, 244, 60, 153, 107, 243, 29, 132, 120, 67, 220, 251, 129, 159, 56, 194, 40, 240, 9, 11, 118, 227, 97, 149, 63, 215, 177, 80, 249, 137, 147, 164, 209, 45, 12, 219, 2, 27, 124, 87, 56, 122, 31, 142, 91, 87, 5, 242, 88, 212, 172, 99, 79, 143, 234, 251, 70, 140, 212, 23, 245, 128, 224, 114, 150, 53, 225, 27, 103, 174, 60, 216, 157, 229, 207, 144, 236, 81, 228, 196, 185, 3, 83, 63, 91, 24, 116, 209, 9, 67, 247, 250, 212, 68, 10, 252, 240, 64, 109, 217, 185, 30, 235, 105, 17, 16, 54, 36, 31, 37, 85, 159, 222, 54, 135, 192, 239, 101, 140, 81 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("aec27c4f-a499-42b6-b1e1-8c688760a951"));

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
    }
}
