using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppraisalTool.Persistence.Migrations
{
    public partial class updatedMigrationsWithNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserAuthorityMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ReportingAuthorityId = table.Column<int>(type: "int", nullable: false),
                    ReviewingAuthorityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAuthorityMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAuthorityMappings_User_ReportingAuthorityId",
                        column: x => x.ReportingAuthorityId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAuthorityMappings_User_ReviewingAuthorityId",
                        column: x => x.ReviewingAuthorityId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAuthorityMappings_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserJobRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    JobRoleId = table.Column<int>(type: "int", nullable: false),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: false),
                    IsSecondary = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJobRoles_JobRoles_JobRoleId",
                        column: x => x.JobRoleId,
                        principalTable: "JobRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserJobRoles_User_UserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorityMappings_ReportingAuthorityId",
                table: "UserAuthorityMappings",
                column: "ReportingAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorityMappings_ReviewingAuthorityId",
                table: "UserAuthorityMappings",
                column: "ReviewingAuthorityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAuthorityMappings_UserId",
                table: "UserAuthorityMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobRoles_JobRoleId",
                table: "UserJobRoles",
                column: "JobRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobRoles_UserId",
                table: "UserJobRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserAuthorityMappings");

            migrationBuilder.DropTable(
                name: "UserJobRoles");

            migrationBuilder.DropTable(
                name: "JobRoles");

            migrationBuilder.UpdateData(
                table: "Branch",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedOn",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2023, 8, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2023, 7, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2834));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2023, 2, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2884));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2023, 6, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2941));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2023, 2, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2860));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2023, 4, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2794));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "OrderPlaced",
                value: new DateTime(2022, 10, 17, 9, 52, 19, 335, DateTimeKind.Utc).AddTicks(3111));
        }
    }
}
