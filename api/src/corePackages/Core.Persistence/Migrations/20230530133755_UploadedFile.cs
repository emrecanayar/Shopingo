using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UploadedFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f51dce0d-817e-41ff-8e4e-ddd93c4a95ec"));

            migrationBuilder.CreateTable(
                name: "UploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Directory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileType = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadedFiles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 16, 37, 55, 715, DateTimeKind.Local).AddTicks(9909));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("2d7c039e-2f51-4f7c-b1af-1a7d3ace8132"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 106, 218, 126, 149, 195, 13, 103, 215, 87, 86, 30, 13, 171, 2, 97, 200, 153, 115, 250, 185, 108, 66, 133, 43, 25, 127, 228, 183, 184, 34, 170, 103, 166, 167, 126, 94, 61, 13, 144, 191, 85, 77, 142, 130, 83, 106, 162, 9, 62, 126, 40, 135, 147, 91, 214, 251, 176, 246, 148, 182, 129, 5, 204 }, new byte[] { 0, 21, 112, 151, 218, 178, 229, 40, 13, 41, 80, 222, 129, 177, 217, 255, 176, 251, 208, 18, 238, 88, 69, 76, 145, 148, 24, 137, 207, 47, 239, 107, 48, 159, 168, 94, 77, 73, 139, 37, 52, 151, 217, 191, 54, 227, 9, 116, 180, 11, 57, 67, 71, 157, 66, 3, 69, 0, 41, 222, 78, 21, 253, 168, 152, 177, 64, 134, 71, 94, 26, 112, 215, 50, 141, 192, 21, 106, 227, 174, 219, 66, 229, 96, 158, 201, 119, 70, 115, 48, 178, 8, 20, 247, 77, 2, 253, 2, 62, 154, 136, 220, 30, 41, 0, 25, 83, 129, 250, 22, 179, 56, 210, 143, 119, 45, 217, 153, 165, 135, 141, 60, 123, 221, 24, 41, 164, 223 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadedFiles");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("2d7c039e-2f51-4f7c-b1af-1a7d3ace8132"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 29, 23, 28, 39, 123, DateTimeKind.Local).AddTicks(7800));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("f51dce0d-817e-41ff-8e4e-ddd93c4a95ec"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 14, 25, 155, 75, 47, 200, 116, 147, 146, 133, 152, 24, 217, 2, 62, 60, 211, 87, 179, 180, 243, 31, 68, 231, 152, 88, 134, 219, 140, 175, 172, 177, 137, 28, 143, 142, 217, 179, 101, 148, 6, 40, 9, 236, 73, 103, 163, 215, 68, 167, 82, 94, 50, 9, 111, 90, 64, 131, 155, 19, 125, 180, 251, 216 }, new byte[] { 187, 159, 135, 166, 225, 239, 61, 234, 36, 214, 73, 74, 168, 94, 167, 143, 33, 217, 247, 6, 245, 61, 240, 48, 227, 240, 55, 103, 123, 151, 249, 169, 210, 190, 179, 168, 22, 80, 211, 150, 65, 77, 37, 99, 167, 11, 134, 188, 21, 213, 105, 188, 193, 195, 126, 240, 173, 96, 61, 127, 177, 122, 92, 151, 187, 255, 46, 122, 168, 130, 167, 184, 23, 79, 65, 34, 122, 5, 156, 37, 92, 56, 86, 15, 142, 39, 155, 252, 93, 88, 221, 225, 221, 48, 69, 226, 33, 250, 173, 241, 211, 224, 69, 189, 41, 78, 87, 241, 19, 202, 171, 155, 36, 31, 37, 194, 100, 189, 65, 238, 2, 206, 44, 167, 222, 89, 73, 236 } });
        }
    }
}
