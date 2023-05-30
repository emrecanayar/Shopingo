using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryAndSubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a8cbb040-7e22-4999-8ac3-41f106dcad66"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Key = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("92ef2a00-66d3-41bb-94fc-8b193b6ec13b"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 23, 16, 28, 3, 793, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("a8cbb040-7e22-4999-8ac3-41f106dcad66"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 151, 229, 119, 227, 221, 152, 70, 196, 137, 217, 158, 162, 64, 170, 112, 211, 11, 11, 42, 95, 132, 61, 99, 156, 76, 209, 114, 128, 51, 181, 3, 250, 246, 178, 228, 183, 64, 157, 232, 252, 16, 188, 111, 210, 98, 246, 213, 218, 62, 197, 150, 52, 98, 220, 222, 47, 107, 45, 7, 3, 56, 140, 143, 37 }, new byte[] { 85, 237, 130, 70, 103, 113, 164, 252, 165, 250, 119, 144, 62, 112, 197, 216, 118, 81, 117, 249, 171, 53, 125, 132, 22, 1, 209, 144, 124, 140, 44, 155, 123, 113, 193, 23, 151, 112, 20, 255, 67, 173, 6, 119, 179, 5, 196, 135, 230, 72, 24, 51, 0, 240, 144, 101, 232, 185, 246, 137, 162, 106, 29, 205, 100, 204, 223, 58, 16, 131, 151, 233, 194, 26, 115, 11, 147, 64, 8, 241, 169, 8, 212, 29, 187, 145, 209, 251, 82, 214, 139, 4, 44, 248, 221, 204, 85, 174, 188, 146, 84, 199, 99, 102, 80, 37, 246, 111, 194, 247, 222, 134, 239, 253, 33, 194, 97, 122, 40, 210, 116, 148, 192, 131, 98, 166, 67, 250 } });
        }
    }
}
