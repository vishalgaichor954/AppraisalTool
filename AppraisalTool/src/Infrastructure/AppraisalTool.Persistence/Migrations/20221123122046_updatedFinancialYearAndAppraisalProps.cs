using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class updatedFinancialYearAndAppraisalProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "FinancialYear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "FinancialYear",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "FinancialYear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "FinancialYear",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndDate",
                table: "FinancialYear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FinancialYear",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "FinancialYear",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartDate",
                table: "FinancialYear",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "FinancialYear",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "FinancialYear",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EditRequested",
                table: "Appraisal",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Editable",
                table: "Appraisal",
                type: "bit",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FinancialYear_AddedBy",
                table: "FinancialYear",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialYear_DeletedBy",
                table: "FinancialYear",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialYear_UpdatedBy",
                table: "FinancialYear",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialYear_User_AddedBy",
                table: "FinancialYear",
                column: "AddedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialYear_User_DeletedBy",
                table: "FinancialYear",
                column: "DeletedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FinancialYear_User_UpdatedBy",
                table: "FinancialYear",
                column: "UpdatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FinancialYear_User_AddedBy",
                table: "FinancialYear");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialYear_User_DeletedBy",
                table: "FinancialYear");

            migrationBuilder.DropForeignKey(
                name: "FK_FinancialYear_User_UpdatedBy",
                table: "FinancialYear");

            migrationBuilder.DropIndex(
                name: "IX_FinancialYear_AddedBy",
                table: "FinancialYear");

            migrationBuilder.DropIndex(
                name: "IX_FinancialYear_DeletedBy",
                table: "FinancialYear");

            migrationBuilder.DropIndex(
                name: "IX_FinancialYear_UpdatedBy",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "FinancialYear");

            migrationBuilder.DropColumn(
                name: "EditRequested",
                table: "Appraisal");

            migrationBuilder.DropColumn(
                name: "Editable",
                table: "Appraisal");

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(2061));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1588));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1658));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1565));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1749));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1739));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1714));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1779));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 8, 10, 35, 41, 350, DateTimeKind.Utc).AddTicks(1770));
        }
    }
}
