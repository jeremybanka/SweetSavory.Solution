using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetSavory.Migrations
{
    public partial class PluralizeFlavoringTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flavoring_Flavors_FlavorId",
                table: "Flavoring");

            migrationBuilder.DropForeignKey(
                name: "FK_Flavoring_Treats_TreatId",
                table: "Flavoring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavoring",
                table: "Flavoring");

            migrationBuilder.RenameTable(
                name: "Flavoring",
                newName: "Flavorings");

            migrationBuilder.RenameIndex(
                name: "IX_Flavoring_TreatId",
                table: "Flavorings",
                newName: "IX_Flavorings_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_Flavoring_FlavorId",
                table: "Flavorings",
                newName: "IX_Flavorings_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavorings",
                table: "Flavorings",
                column: "FlavoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flavorings_Flavors_FlavorId",
                table: "Flavorings",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flavorings_Treats_TreatId",
                table: "Flavorings",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flavorings_Flavors_FlavorId",
                table: "Flavorings");

            migrationBuilder.DropForeignKey(
                name: "FK_Flavorings_Treats_TreatId",
                table: "Flavorings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavorings",
                table: "Flavorings");

            migrationBuilder.RenameTable(
                name: "Flavorings",
                newName: "Flavoring");

            migrationBuilder.RenameIndex(
                name: "IX_Flavorings_TreatId",
                table: "Flavoring",
                newName: "IX_Flavoring_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_Flavorings_FlavorId",
                table: "Flavoring",
                newName: "IX_Flavoring_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavoring",
                table: "Flavoring",
                column: "FlavoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flavoring_Flavors_FlavorId",
                table: "Flavoring",
                column: "FlavorId",
                principalTable: "Flavors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flavoring_Treats_TreatId",
                table: "Flavoring",
                column: "TreatId",
                principalTable: "Treats",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
