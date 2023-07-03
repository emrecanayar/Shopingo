using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserModifiedByCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4478c528-8d45-41d7-83bc-af8daf93232b"));

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("d3b9f1f7-491b-4a4a-abbd-9c3ed3dd722c"));

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 3, 16, 38, 47, 873, DateTimeKind.Local).AddTicks(3650));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("bf37360c-d755-45d6-a638-61f6fdafc5d5"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 43, 217, 152, 181, 212, 219, 81, 151, 3, 43, 83, 213, 225, 149, 79, 111, 95, 234, 57, 87, 51, 227, 115, 254, 94, 6, 60, 240, 9, 67, 203, 156, 240, 34, 144, 68, 132, 221, 62, 254, 67, 210, 160, 65, 229, 27, 129, 80, 156, 161, 44, 253, 55, 183, 205, 128, 118, 181, 214, 11, 160, 252, 159, 52 }, new byte[] { 36, 122, 204, 41, 225, 146, 2, 10, 8, 45, 236, 110, 164, 122, 17, 36, 69, 98, 99, 161, 167, 197, 211, 92, 90, 115, 123, 245, 34, 27, 133, 143, 68, 235, 139, 148, 191, 211, 79, 117, 101, 18, 11, 108, 177, 134, 42, 59, 6, 108, 162, 183, 223, 63, 239, 23, 31, 47, 250, 203, 135, 65, 14, 115, 121, 111, 105, 157, 68, 74, 121, 177, 102, 192, 6, 147, 143, 94, 107, 157, 81, 146, 64, 96, 29, 144, 222, 91, 145, 250, 229, 111, 69, 66, 74, 73, 232, 87, 208, 55, 151, 124, 14, 50, 151, 95, 250, 72, 30, 13, 247, 249, 232, 48, 61, 237, 80, 248, 87, 6, 254, 189, 189, 104, 138, 250, 237, 142 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Countries_CountryId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CountryId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bf37360c-d755-45d6-a638-61f6fdafc5d5"));

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Users");

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
    }
}
