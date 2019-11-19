using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alphasoft.Migrations
{
    public partial class BlogUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Blogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blogs");
        }
    }
}
