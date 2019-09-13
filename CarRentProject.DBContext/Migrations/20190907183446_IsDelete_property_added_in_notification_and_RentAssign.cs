using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentProject.DBContext.Migrations
{
    public partial class IsDelete_property_added_in_notification_and_RentAssign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "RentAssigns",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "Notifications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "RentAssigns");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "Notifications");
        }
    }
}
