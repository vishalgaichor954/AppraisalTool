using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Identity.Migrations
{
    public partial class JobRolesMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b6b5757-a55c-479b-b065-326bff14e121");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9185fc2a-50c0-4ad1-9378-5ab7149ef882");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af05ecc5-c768-4027-a0c9-1e72df9d2110");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c714653d-ac43-4bb4-8b6d-3ed4cd9f6f09");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e610f92a-dc59-43aa-9a92-5200d4e6aa30");

            migrationBuilder.DropColumn(
                name: "AdditionalRole1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdditionalRole2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdditionalRole3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AdditionalRole4",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimaryJobRole",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18c18e2a-93cb-4d3c-8c09-93a6ab956498", "45d7e596-28ba-4cd2-afc4-52ebd1aa3f02", "Employee", "EMPLOYEE" },
                    { "374411ae-839a-4759-89da-104f8b91bfa3", "aab54a14-85ac-4732-8e5d-6e9f5734f0b3", "ReviewingAuthority", "REVIEWINGAUTHORITY" },
                    { "668d53c2-7a0f-48f5-ad17-4fade9756dcb", "fb7a5a93-686d-4077-8bb6-f8b695f01d58", "ReportingAuthority", "REPORTINGAUTHORITY" },
                    { "938da5f4-4a02-45a7-b7b1-0eeb6fa88647", "5861a9c0-37db-4626-acde-6828bab72789", "Administrator", "ADMINISTRATOR" },
                    { "b1461ae9-b293-4adc-b058-45739f62deb0", "5bf9c48d-86be-49b8-ae8e-bc8b68fe6852", "Viewer", "VIEWER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18c18e2a-93cb-4d3c-8c09-93a6ab956498");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "374411ae-839a-4759-89da-104f8b91bfa3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "668d53c2-7a0f-48f5-ad17-4fade9756dcb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "938da5f4-4a02-45a7-b7b1-0eeb6fa88647");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1461ae9-b293-4adc-b058-45739f62deb0");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRole1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRole2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRole3",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdditionalRole4",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimaryJobRole",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b6b5757-a55c-479b-b065-326bff14e121", "8048092c-77ef-4bec-bb59-e0470c74dbac", "Viewer", "VIEWER" },
                    { "9185fc2a-50c0-4ad1-9378-5ab7149ef882", "1ace1198-c8ca-4161-b2a9-d5cf33516dae", "Administrator", "ADMINISTRATOR" },
                    { "af05ecc5-c768-4027-a0c9-1e72df9d2110", "4e5e53f1-1e03-49bc-8043-41482dc62ea7", "ReviewingAuthority", "REVIEWINGAUTHORITY" },
                    { "c714653d-ac43-4bb4-8b6d-3ed4cd9f6f09", "d8c241f1-669f-435e-9521-c0e6359d556a", "ReportingAuthority", "REPORTINGAUTHORITY" },
                    { "e610f92a-dc59-43aa-9a92-5200d4e6aa30", "753494cc-d93e-4f97-89aa-b0367ad2be8a", "Employee", "EMPLOYEE" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_AspNetUsers_ApplicationUserId",
                table: "RefreshToken",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
