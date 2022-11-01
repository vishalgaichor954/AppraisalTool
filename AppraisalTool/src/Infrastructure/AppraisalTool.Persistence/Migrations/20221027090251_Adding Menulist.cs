using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class AddingMenulist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuLists",
                columns: table => new
                {
                    Menu_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuIcon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuLists", x => x.Menu_Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuRoleMappings",
                columns: table => new
                {
                    MenuRoleMapping_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Menu_id = table.Column<int>(type: "int", nullable: false),
                    Role_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRoleMappings", x => x.MenuRoleMapping_id);
                    table.ForeignKey(
                        name: "FK_MenuRoleMappings_MenuLists_Role_id",
                        column: x => x.Role_id,
                        principalTable: "MenuLists",
                        principalColumn: "Menu_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuRoleMappings_UserRole_Menu_id",
                        column: x => x.Menu_id,
                        principalTable: "UserRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(4541));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 8, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 7, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 2, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3776));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 6, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3813));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 2, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3760));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 4, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3707));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3880));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3831));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3852));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3926));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3894));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 27, 9, 2, 50, 513, DateTimeKind.Utc).AddTicks(3912));

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRoleMappings_Menu_id",
                table: "MenuRoleMappings",
                column: "Menu_id");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRoleMappings_Role_id",
                table: "MenuRoleMappings",
                column: "Role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRole_RoleId",
                table: "User",
                column: "RoleId",
                principalTable: "UserRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRole_RoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "MenuRoleMappings");

            migrationBuilder.DropTable(
                name: "MenuLists");

            migrationBuilder.DropIndex(
                name: "IX_User_RoleId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 8, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3873));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 7, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 2, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3862));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 6, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3887));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 2, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 4, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3814));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(4004));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3992));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3904));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(3920));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(4040));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(4015));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 12, 25, 25, 195, DateTimeKind.Utc).AddTicks(4029));
        }
    }
}
