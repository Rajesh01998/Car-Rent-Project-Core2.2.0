using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentProject.DBContext.Migrations
{
    public partial class IsDelete_property_added_in_vehicleType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "VehicleTypes",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "VehicleTypes");
        }
    }
}
