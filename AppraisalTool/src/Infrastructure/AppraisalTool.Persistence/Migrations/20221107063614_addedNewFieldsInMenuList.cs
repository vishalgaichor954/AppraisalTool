using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class addedNewFieldsInMenuList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "MenuLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "MenuLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "MenuLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "MenuLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuLists",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MenuLink",
                table: "MenuLists",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "MenuLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "MenuLists",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "SelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "RevaSelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RevaSelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RevaSelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "RepaSelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RepaSelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "RepaSelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "MetricWeightage",
                table: "AppraisalResult",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "MetricDescription",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1629));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1575));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1612));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1652));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1540));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1704));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1796));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1758));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 7, 6, 36, 13, 851, DateTimeKind.Utc).AddTicks(1778));

            migrationBuilder.CreateIndex(
                name: "IX_MenuLists_AddedBy",
                table: "MenuLists",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLists_DeletedBy",
                table: "MenuLists",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_MenuLists_UpdatedBy",
                table: "MenuLists",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLists_User_AddedBy",
                table: "MenuLists",
                column: "AddedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLists_User_DeletedBy",
                table: "MenuLists",
                column: "DeletedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuLists_User_UpdatedBy",
                table: "MenuLists",
                column: "UpdatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuLists_User_AddedBy",
                table: "MenuLists");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuLists_User_DeletedBy",
                table: "MenuLists");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuLists_User_UpdatedBy",
                table: "MenuLists");

            migrationBuilder.DropIndex(
                name: "IX_MenuLists_AddedBy",
                table: "MenuLists");

            migrationBuilder.DropIndex(
                name: "IX_MenuLists_DeletedBy",
                table: "MenuLists");

            migrationBuilder.DropIndex(
                name: "IX_MenuLists_UpdatedBy",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "MenuLink",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "MenuLists");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "MenuLists");

            migrationBuilder.AlterColumn<double>(
                name: "SelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "SelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RevaSelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RevaSelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RevaSelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "RepaSelfScore",
                table: "AppraisalResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RepaSelfCreatatedDate",
                table: "AppraisalResult",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RepaSelfComment",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "MetricWeightage",
                table: "AppraisalResult",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MetricDescription",
                table: "AppraisalResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9875));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9465));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9454));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9442));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9407));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9578));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9610));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9588));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 3, 5, 38, 31, 749, DateTimeKind.Utc).AddTicks(9600));
        }
    }
}
