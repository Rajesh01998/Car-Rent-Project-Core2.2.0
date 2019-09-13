using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentProject.DBContext.Migrations
{
    public partial class notification_and_rentAssign_Table_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<string>(nullable: false),
                    Details = table.Column<string>(nullable: false),
                    NotificationDateTime = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    RentRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notifications_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentAssigns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RentPrice = table.Column<double>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    RentAssignDateTime = table.Column<DateTime>(nullable: false),
                    VehicleId = table.Column<int>(nullable: false),
                    RentRequestId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentAssigns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentAssigns_RentRequests_RentRequestId",
                        column: x => x.RentRequestId,
                        principalTable: "RentRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentAssigns_VehicleTypes_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CustomerId",
                table: "Notifications",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RentRequestId",
                table: "Notifications",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RentAssigns_RentRequestId",
                table: "RentAssigns",
                column: "RentRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RentAssigns_VehicleId",
                table: "RentAssigns",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "RentAssigns");
        }
    }
}
