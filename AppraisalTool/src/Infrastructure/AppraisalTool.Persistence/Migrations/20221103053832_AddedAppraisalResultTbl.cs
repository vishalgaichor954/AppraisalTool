using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class AddedAppraisalResultTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppraisalResult",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    KraListId = table.Column<int>(type: "int", nullable: false),
                    MetricId = table.Column<int>(type: "int", nullable: false),
                    MetricDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MetricWeightage = table.Column<double>(type: "float", nullable: false),
                    SelfScore = table.Column<double>(type: "float", nullable: false),
                    SelfComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelfCreatatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RepaSelfScore = table.Column<double>(type: "float", nullable: false),
                    RepaSelfComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepaSelfCreatatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevaSelfScore = table.Column<double>(type: "float", nullable: false),
                    RevaSelfComment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RevaSelfCreatatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppraisalResult", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppraisalResult_ListOfKras_KraListId",
                        column: x => x.KraListId,
                        principalTable: "ListOfKras",
                        principalColumn: "List_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppraisalResult_listOfMetrics_MetricId",
                        column: x => x.MetricId,
                        principalTable: "listOfMetrics",
                        principalColumn: "Metric_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppraisalResult_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AppraisalResult_KraListId",
                table: "AppraisalResult",
                column: "KraListId");

            migrationBuilder.CreateIndex(
                name: "IX_AppraisalResult_MetricId",
                table: "AppraisalResult",
                column: "MetricId");

            migrationBuilder.CreateIndex(
                name: "IX_AppraisalResult_UserId",
                table: "AppraisalResult",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppraisalResult");

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(9586));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 9, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8354));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 8, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8233));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 3, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8317));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 7, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 3, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8274));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 5, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8581));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8549));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8614));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 11, 2, 9, 48, 49, 506, DateTimeKind.Utc).AddTicks(8658));
        }
    }
}
