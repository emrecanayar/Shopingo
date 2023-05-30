using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactInfoModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("17335687-bdcc-4b95-a0e0-a0496855fb62"));

            migrationBuilder.RenameTable(
                name: "ContactInfo",
                newName: "ContactInfos");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingDay",
                table: "ContactInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "ContactInfos",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfos",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressTextKey",
                table: "ContactInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressText",
                table: "ContactInfos",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactInfos",
                table: "ContactInfos");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f51dce0d-817e-41ff-8e4e-ddd93c4a95ec"));

            migrationBuilder.RenameTable(
                name: "ContactInfos",
                newName: "ContactInfo");

            migrationBuilder.AlterColumn<string>(
                name: "WorkingDay",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40);

            migrationBuilder.AlterColumn<string>(
                name: "AddressTextKey",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AddressText",
                table: "ContactInfo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactInfo",
                table: "ContactInfo",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"),
                column: "CreatedDate",
                value: new DateTime(2023, 5, 29, 23, 18, 48, 760, DateTimeKind.Local).AddTicks(2714));

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("17335687-bdcc-4b95-a0e0-a0496855fb62"), "System", new DateTime(2023, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, new Guid("d2e414d0-8a10-4b54-8858-3a8200f0a6f9"), 1, new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8ad7fb9c-da00-4ca1-b8d5-ff636ff1ccb0"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 117, 158, 25, 159, 222, 17, 8, 201, 75, 12, 79, 145, 63, 119, 204, 0, 168, 157, 94, 71, 47, 103, 21, 194, 43, 228, 212, 227, 192, 206, 129, 86, 192, 146, 9, 116, 231, 88, 8, 166, 87, 137, 1, 160, 110, 123, 130, 144, 38, 71, 175, 40, 76, 144, 207, 76, 45, 239, 188, 144, 163, 88, 213, 17 }, new byte[] { 241, 244, 191, 199, 232, 61, 68, 52, 163, 136, 234, 15, 152, 33, 206, 86, 106, 162, 122, 230, 22, 57, 33, 101, 80, 176, 205, 92, 52, 167, 176, 105, 119, 221, 210, 132, 249, 105, 51, 160, 19, 217, 184, 158, 109, 38, 234, 129, 31, 115, 122, 3, 66, 114, 199, 252, 0, 254, 12, 225, 180, 83, 153, 166, 113, 64, 99, 159, 224, 158, 81, 12, 157, 96, 236, 6, 77, 235, 15, 2, 186, 129, 75, 239, 182, 156, 188, 12, 12, 167, 94, 51, 249, 69, 205, 91, 177, 108, 116, 247, 186, 38, 116, 66, 23, 174, 189, 220, 176, 159, 14, 41, 61, 251, 187, 213, 85, 232, 175, 9, 221, 217, 250, 75, 165, 200, 201, 149 } });
        }
    }
}
