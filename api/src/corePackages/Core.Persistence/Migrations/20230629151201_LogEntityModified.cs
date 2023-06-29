using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LogEntityModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5ac976af-556e-4c70-ba5a-906d14d5fd76"));

            migrationBuilder.AddColumn<string>(
                name: "GetErrorLog",
                table: "Logs",
                type: "nvarchar(MAX)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GetLog",
                table: "Logs",
                type: "nvarchar(MAX)",
                nullable: true);

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
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 110, 67, 25, 216, 46, 45, 139, 15, 153, 120, 171, 145, 131, 168, 99, 220, 38, 45, 38, 253, 181, 104, 92, 230, 123, 18, 114, 62, 33, 226, 138, 183, 69, 4, 114, 17, 114, 72, 177, 48, 218, 195, 51, 51, 121, 153, 58, 208, 14, 201, 229, 238, 23, 239, 57, 234, 162, 219, 247, 182, 76, 48, 124, 211 }, new byte[] { 101, 58, 24, 24, 191, 149, 47, 202, 190, 45, 163, 102, 108, 174, 11, 24, 154, 152, 188, 141, 152, 235, 73, 32, 32, 3, 202, 175, 35, 252, 251, 230, 151, 214, 45, 63, 15, 74, 161, 123, 88, 15, 88, 112, 214, 125, 123, 204, 17, 63, 101, 157, 246, 215, 77, 52, 28, 124, 109, 44, 166, 91, 247, 119, 219, 71, 225, 188, 39, 158, 123, 52, 175, 153, 49, 152, 56, 82, 202, 18, 133, 239, 157, 240, 182, 197, 78, 13, 74, 58, 68, 87, 98, 169, 254, 94, 199, 215, 250, 243, 164, 10, 86, 126, 22, 42, 228, 84, 130, 164, 168, 154, 30, 90, 194, 255, 227, 222, 145, 215, 70, 191, 242, 155, 176, 194, 242, 91 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("091a4649-e1aa-4e8d-91cc-58c82a37d9eb"));

            migrationBuilder.DropColumn(
                name: "GetErrorLog",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "GetLog",
                table: "Logs");

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
    }
}
