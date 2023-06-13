using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactUsFormsEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("14fa0347-9e25-4d33-b682-bb6e500268d1"));

            migrationBuilder.DropColumn(
                name: "Text",
                table: "ContactUsForms");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "ContactUsForms",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 13, 19, 5, 22, 867, DateTimeKind.Local).AddTicks(1999));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("f76e29a9-f7c0-491e-9668-c5459c205806"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 163, 16, 254, 161, 254, 5, 104, 116, 32, 51, 134, 75, 23, 147, 34, 155, 219, 209, 150, 212, 166, 112, 37, 211, 129, 87, 89, 88, 141, 179, 46, 29, 97, 239, 7, 42, 215, 223, 242, 223, 93, 58, 157, 228, 69, 251, 129, 49, 29, 230, 19, 189, 39, 226, 140, 42, 202, 238, 49, 194, 9, 28, 105, 80 }, new byte[] { 18, 93, 214, 59, 2, 18, 1, 45, 138, 50, 241, 19, 191, 2, 153, 172, 44, 151, 148, 104, 137, 90, 81, 212, 218, 238, 24, 10, 217, 168, 228, 78, 203, 198, 26, 244, 108, 48, 9, 91, 251, 111, 168, 188, 248, 209, 122, 125, 20, 106, 49, 139, 248, 10, 83, 88, 125, 160, 8, 37, 78, 81, 253, 89, 47, 220, 250, 16, 193, 195, 54, 190, 0, 155, 90, 11, 246, 180, 50, 156, 82, 225, 42, 193, 113, 112, 192, 29, 154, 185, 48, 30, 160, 253, 147, 210, 147, 196, 28, 57, 173, 164, 154, 138, 48, 128, 60, 143, 251, 100, 114, 239, 248, 210, 64, 134, 157, 124, 96, 170, 215, 247, 198, 156, 175, 137, 181, 0 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f76e29a9-f7c0-491e-9668-c5459c205806"));

            migrationBuilder.DropColumn(
                name: "Message",
                table: "ContactUsForms");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "ContactUsForms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
