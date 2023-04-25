using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripWiseApplication.Migrations
{
    public partial class updateCustomerWithIsUserAuthenticatedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserAuthenticated",
                table: "Customer",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserAuthenticated",
                table: "Customer");
        }
    }
}
