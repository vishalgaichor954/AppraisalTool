using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class addedauditproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "UserRole",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserRole",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "UserRole",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "JobRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "JobRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "JobRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "JobRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "JobRoles",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "JobRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "JobRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy",
                table: "Branch",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Branch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Branch",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Branch",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Branch",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddedOn", "DeletedOn", "IsDeleted", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2032), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2033), false, new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2033) });

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
                columns: new[] { "AddedOn", "DeletedOn", "IsDeleted", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1985), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1988), false, new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(1988) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddedOn", "DeletedOn", "IsDeleted", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2003), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2004), false, new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2004) });

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AddedOn", "DeletedOn", "IsDeleted", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2014), new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2015), false, new DateTime(2022, 12, 5, 6, 6, 4, 110, DateTimeKind.Utc).AddTicks(2015) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "JobRoles");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Branch");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Branch");

            migrationBuilder.AlterColumn<string>(
                name: "AddedBy",
                table: "Branch",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(5222));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4730));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4752));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4833));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4741));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4878));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4922));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 23, 12, 20, 46, 50, DateTimeKind.Utc).AddTicks(4912));
        }
    }
}
