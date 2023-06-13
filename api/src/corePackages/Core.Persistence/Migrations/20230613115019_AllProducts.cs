using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AllProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("484dfe5f-a50c-4b55-bfec-b7c1a387efd7"));

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 13, 14, 50, 18, 646, DateTimeKind.Local).AddTicks(3399));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("fe065008-277f-479c-be14-f99646597405"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 79, 105, 108, 168, 52, 92, 103, 253, 12, 88, 59, 231, 149, 216, 138, 248, 36, 2, 169, 73, 5, 93, 208, 222, 144, 78, 15, 55, 53, 16, 202, 92, 71, 8, 159, 227, 2, 208, 54, 248, 239, 36, 83, 119, 236, 180, 103, 247, 242, 232, 91, 64, 41, 170, 144, 218, 28, 221, 4, 163, 196, 240, 108, 134 }, new byte[] { 104, 246, 228, 34, 145, 111, 233, 168, 211, 172, 59, 177, 26, 75, 234, 198, 252, 246, 125, 69, 213, 206, 132, 127, 69, 206, 93, 114, 177, 183, 220, 0, 235, 137, 135, 207, 168, 96, 158, 116, 111, 35, 97, 95, 97, 15, 53, 163, 239, 145, 111, 121, 173, 164, 25, 152, 127, 241, 67, 236, 150, 237, 145, 254, 197, 88, 66, 240, 67, 35, 207, 159, 226, 125, 194, 32, 4, 68, 193, 96, 124, 179, 31, 88, 251, 150, 57, 230, 44, 15, 70, 17, 76, 20, 72, 58, 223, 141, 46, 229, 157, 147, 47, 114, 164, 24, 93, 198, 40, 147, 153, 119, 161, 168, 162, 17, 226, 183, 141, 199, 119, 31, 197, 249, 22, 124, 76, 46 } });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ProductId",
                table: "ProductCategories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_SubCategoryId",
                table: "ProductCategories",
                column: "SubCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fe065008-277f-479c-be14-f99646597405"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 30, 19, 42, 46, 29, DateTimeKind.Local).AddTicks(2074));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("484dfe5f-a50c-4b55-bfec-b7c1a387efd7"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 70, 147, 133, 89, 114, 247, 117, 38, 45, 50, 5, 30, 160, 167, 221, 108, 245, 84, 197, 30, 148, 214, 131, 205, 207, 57, 146, 121, 107, 19, 178, 68, 247, 40, 69, 228, 83, 170, 107, 30, 170, 162, 178, 65, 72, 21, 64, 239, 49, 1, 237, 213, 253, 84, 100, 140, 148, 51, 102, 120, 248, 71, 223, 224 }, new byte[] { 136, 233, 155, 216, 248, 201, 30, 55, 226, 55, 164, 47, 167, 176, 128, 246, 41, 202, 15, 78, 235, 211, 124, 170, 76, 113, 27, 14, 23, 174, 191, 100, 51, 157, 127, 102, 64, 196, 169, 76, 215, 51, 73, 132, 26, 151, 146, 20, 104, 208, 248, 216, 222, 35, 37, 189, 189, 69, 165, 18, 121, 167, 41, 182, 84, 178, 190, 239, 112, 19, 201, 227, 234, 42, 67, 178, 36, 94, 31, 170, 7, 172, 139, 150, 26, 136, 66, 181, 134, 233, 215, 181, 32, 183, 129, 147, 11, 255, 243, 75, 181, 118, 123, 56, 82, 236, 239, 98, 177, 166, 219, 214, 187, 245, 52, 229, 214, 89, 241, 17, 87, 62, 118, 152, 189, 178, 129, 30 } });
        }
    }
}
