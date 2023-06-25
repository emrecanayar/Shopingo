using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AboutUsModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("aec27c4f-a499-42b6-b1e1-8c688760a951"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AboutUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TitleKey",
                table: "AboutUs",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 25, 19, 39, 35, 13, DateTimeKind.Local).AddTicks(9215));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("5ac976af-556e-4c70-ba5a-906d14d5fd76"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 72, 133, 145, 200, 85, 200, 135, 123, 162, 214, 255, 96, 75, 6, 194, 22, 159, 236, 157, 72, 66, 74, 45, 117, 30, 235, 86, 172, 1, 115, 219, 179, 34, 234, 12, 175, 51, 157, 252, 41, 32, 176, 112, 157, 74, 247, 10, 176, 42, 57, 149, 139, 144, 159, 206, 227, 55, 246, 138, 75, 211, 155, 117, 28 }, new byte[] { 176, 162, 167, 154, 243, 84, 54, 118, 56, 12, 148, 210, 170, 30, 88, 165, 186, 233, 163, 152, 93, 209, 155, 99, 43, 158, 198, 18, 133, 122, 106, 53, 168, 70, 122, 126, 254, 220, 221, 212, 245, 201, 38, 53, 15, 231, 239, 111, 121, 202, 66, 241, 219, 130, 197, 243, 96, 186, 230, 80, 215, 23, 98, 99, 255, 188, 249, 32, 255, 175, 118, 189, 220, 182, 83, 3, 128, 101, 13, 109, 24, 187, 87, 188, 127, 51, 234, 85, 86, 132, 65, 242, 168, 15, 201, 21, 176, 189, 222, 42, 165, 136, 167, 3, 63, 102, 18, 125, 43, 0, 238, 50, 48, 131, 80, 102, 83, 162, 179, 47, 207, 65, 129, 237, 119, 188, 76, 4 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5ac976af-556e-4c70-ba5a-906d14d5fd76"));

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "TitleKey",
                table: "AboutUs");

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
    }
}
