using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alphasoft.Migrations
{
    public partial class aboutUs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutMainSologanDescription",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ImageOne",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ImageThree",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "ImageTwo",
                table: "AboutUs");

            migrationBuilder.DropColumn(
                name: "OurMission",
                table: "AboutUs");

            migrationBuilder.RenameColumn(
                name: "WhyUs",
                table: "AboutUs",
                newName: "WhoWeAreImageTwo");

            migrationBuilder.RenameColumn(
                name: "WhoWeAre",
                table: "AboutUs",
                newName: "WhoWeAreImageOne");

            migrationBuilder.RenameColumn(
                name: "OurVissionDescription",
                table: "AboutUs",
                newName: "WhoWeAreDescription");

            migrationBuilder.RenameColumn(
                name: "OurVission",
                table: "AboutUs",
                newName: "OurVisionDescription");

            migrationBuilder.CreateTable(
                name: "CustomerRivew",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRivew", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRivew");

            migrationBuilder.RenameColumn(
                name: "WhoWeAreImageTwo",
                table: "AboutUs",
                newName: "WhyUs");

            migrationBuilder.RenameColumn(
                name: "WhoWeAreImageOne",
                table: "AboutUs",
                newName: "WhoWeAre");

            migrationBuilder.RenameColumn(
                name: "WhoWeAreDescription",
                table: "AboutUs",
                newName: "OurVissionDescription");

            migrationBuilder.RenameColumn(
                name: "OurVisionDescription",
                table: "AboutUs",
                newName: "OurVission");

            migrationBuilder.AddColumn<string>(
                name: "AboutMainSologanDescription",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageOne",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageThree",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageTwo",
                table: "AboutUs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurMission",
                table: "AboutUs",
                nullable: true);
        }
    }
}
