using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetSavory.Migrations
{
    public partial class NamesForFlavorsAndTreats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Treats",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Flavors",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Treats");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Flavors");
        }
    }
}
