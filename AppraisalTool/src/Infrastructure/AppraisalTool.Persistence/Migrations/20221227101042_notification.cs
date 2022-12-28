using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class notification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserJobRoles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NotificationText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2762), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2762), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2763) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 10, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2321));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 9, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 4, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 8, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2336));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 4, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 6, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2253));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2404));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2383));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2354));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2445));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2433));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2708), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2711), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2711) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2730), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2730), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2731) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2742), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2743), new DateTime(2022, 12, 27, 10, 10, 41, 149, DateTimeKind.Utc).AddTicks(2743) });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UserJobRoles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2032), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2033), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 10, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1574));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 9, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1435));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 4, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1558));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 8, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1591));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 4, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 6, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1650));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1639));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1610));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1627));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1661));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1985), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1988), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2003), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2004), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedOn", "DeletedOn", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2014), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2015), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2015) });
        }
    }
}
