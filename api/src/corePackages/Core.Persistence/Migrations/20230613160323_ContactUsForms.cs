using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactUsForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fe065008-277f-479c-be14-f99646597405"));

            migrationBuilder.CreateTable(
                name: "ContactUsForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUsForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUsForms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 13, 19, 3, 23, 254, DateTimeKind.Local).AddTicks(674));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("14fa0347-9e25-4d33-b682-bb6e500268d1"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 203, 201, 29, 224, 53, 145, 174, 155, 222, 232, 129, 43, 29, 146, 221, 184, 9, 167, 84, 86, 204, 26, 253, 152, 16, 32, 14, 134, 108, 98, 35, 154, 7, 124, 52, 192, 164, 11, 220, 86, 178, 116, 98, 159, 255, 171, 37, 194, 39, 89, 170, 12, 209, 160, 187, 234, 99, 147, 236, 200, 100, 44, 53, 105 }, new byte[] { 163, 13, 150, 104, 63, 15, 247, 240, 143, 223, 182, 73, 15, 100, 109, 68, 255, 249, 153, 121, 69, 253, 193, 26, 247, 79, 36, 41, 110, 58, 232, 211, 218, 27, 13, 178, 38, 91, 237, 247, 225, 163, 192, 66, 201, 169, 93, 39, 94, 58, 0, 119, 22, 20, 180, 232, 34, 141, 71, 142, 174, 165, 94, 201, 90, 133, 56, 95, 78, 94, 81, 248, 146, 241, 215, 123, 80, 62, 187, 33, 187, 19, 141, 117, 101, 44, 162, 177, 117, 251, 182, 87, 67, 33, 107, 136, 16, 237, 98, 124, 183, 137, 111, 26, 7, 194, 214, 217, 196, 53, 251, 206, 99, 37, 209, 5, 121, 234, 9, 193, 227, 192, 15, 212, 138, 61, 216, 195 } });

            migrationBuilder.CreateIndex(
                name: "IX_ContactUsForms_UserId",
                table: "ContactUsForms",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUsForms");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("14fa0347-9e25-4d33-b682-bb6e500268d1"));

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
        }
    }
}
