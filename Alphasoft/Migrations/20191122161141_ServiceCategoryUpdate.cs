using Microsoft.EntityFrameworkCore.Migrations;

namespace Alphasoft.Migrations
{
    public partial class ServiceCategoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ServiceCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "ServiceCategories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ServiceCategories");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ServiceCategories");
        }
    }
}
