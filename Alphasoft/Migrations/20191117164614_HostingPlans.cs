using Microsoft.EntityFrameworkCore.Migrations;

namespace Alphasoft.Migrations
{
    public partial class HostingPlans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "HostingPlan",
                newName: "YearlyPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPrice",
                table: "HostingPlan",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonthlyPrice",
                table: "HostingPlan");

            migrationBuilder.RenameColumn(
                name: "YearlyPrice",
                table: "HostingPlan",
                newName: "Price");
        }
    }
}
