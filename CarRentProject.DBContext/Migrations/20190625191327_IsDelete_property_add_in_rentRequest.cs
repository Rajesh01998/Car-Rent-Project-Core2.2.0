using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentProject.DBContext.Migrations
{
    public partial class IsDelete_property_add_in_rentRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "RentRequests",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "RentRequests");
        }
    }
}
