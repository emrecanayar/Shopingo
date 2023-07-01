using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("091a4649-e1aa-4e8d-91cc-58c82a37d9eb"));

            migrationBuilder.DropColumn(
                name: "UserType",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 7, 2, 2, 2, 19, 172, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("1f7db4d9-d4ec-4d4b-b18c-6e995a6aa5c2"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 129, 100, 188, 163, 170, 94, 252, 146, 47, 220, 155, 158, 160, 164, 43, 218, 29, 150, 196, 247, 82, 164, 56, 153, 187, 230, 166, 81, 111, 69, 17, 199, 174, 81, 76, 159, 200, 216, 201, 36, 146, 186, 174, 131, 176, 154, 13, 80, 183, 200, 155, 207, 54, 70, 137, 25, 219, 253, 251, 156, 5, 188, 35, 57 }, new byte[] { 23, 7, 27, 74, 28, 244, 45, 237, 63, 202, 45, 73, 76, 186, 72, 150, 10, 38, 69, 249, 254, 61, 84, 74, 164, 114, 2, 193, 137, 69, 254, 208, 174, 110, 197, 9, 121, 18, 252, 162, 142, 210, 82, 58, 56, 199, 41, 18, 209, 160, 89, 184, 34, 254, 177, 154, 40, 125, 60, 128, 33, 49, 15, 120, 148, 44, 182, 214, 155, 21, 43, 177, 232, 78, 230, 184, 153, 96, 27, 35, 3, 232, 200, 135, 203, 178, 61, 53, 98, 85, 46, 118, 43, 181, 29, 166, 206, 193, 8, 194, 35, 29, 255, 163, 198, 136, 28, 243, 162, 144, 43, 178, 199, 23, 87, 242, 35, 149, 106, 86, 164, 238, 98, 223, 252, 89, 181, 100 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1f7db4d9-d4ec-4d4b-b18c-6e995a6aa5c2"));

            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 6, 29, 18, 12, 1, 33, DateTimeKind.Local).AddTicks(1935));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("091a4649-e1aa-4e8d-91cc-58c82a37d9eb"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt", "UserType" },
                values: new object[] { new byte[] { 110, 67, 25, 216, 46, 45, 139, 15, 153, 120, 171, 145, 131, 168, 99, 220, 38, 45, 38, 253, 181, 104, 92, 230, 123, 18, 114, 62, 33, 226, 138, 183, 69, 4, 114, 17, 114, 72, 177, 48, 218, 195, 51, 51, 121, 153, 58, 208, 14, 201, 229, 238, 23, 239, 57, 234, 162, 219, 247, 182, 76, 48, 124, 211 }, new byte[] { 101, 58, 24, 24, 191, 149, 47, 202, 190, 45, 163, 102, 108, 174, 11, 24, 154, 152, 188, 141, 152, 235, 73, 32, 32, 3, 202, 175, 35, 252, 251, 230, 151, 214, 45, 63, 15, 74, 161, 123, 88, 15, 88, 112, 214, 125, 123, 204, 17, 63, 101, 157, 246, 215, 77, 52, 28, 124, 109, 44, 166, 91, 247, 119, 219, 71, 225, 188, 39, 158, 123, 52, 175, 153, 49, 152, 56, 82, 202, 18, 133, 239, 157, 240, 182, 197, 78, 13, 74, 58, 68, 87, 98, 169, 254, 94, 199, 215, 250, 243, 164, 10, 86, 126, 22, 42, 228, 84, 130, 164, 168, 154, 30, 90, 194, 255, 227, 222, 145, 215, 70, 191, 242, 155, 176, 194, 242, 91 }, 1 });
        }
    }
}
