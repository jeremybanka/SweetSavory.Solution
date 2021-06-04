using Microsoft.EntityFrameworkCore.Migrations;

namespace SweetSavory.Migrations
{
    public partial class FixPropertyTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Opera_Authors_FlavorId",
                table: "Opera");

            migrationBuilder.DropForeignKey(
                name: "FK_Opera_Books_TreatId",
                table: "Opera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Opera",
                table: "Opera");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Opera",
                newName: "Flavoring");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "Treats");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Flavors");

            migrationBuilder.RenameIndex(
                name: "IX_Opera_TreatId",
                table: "Flavoring",
                newName: "IX_Flavoring_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_Opera_FlavorId",
                table: "Flavoring",
                newName: "IX_Flavoring_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavoring",
                table: "Flavoring",
                column: "FlavoringId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treats",
                table: "Treats",
                column: "TreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flavors",
                table: "Flavors",
                column: "FlavorId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flavoring_Flavors_FlavorId",
                table: "Flavoring");

            migrationBuilder.DropForeignKey(
                name: "FK_Flavoring_Treats_TreatId",
                table: "Flavoring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treats",
                table: "Treats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavors",
                table: "Flavors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flavoring",
                table: "Flavoring");

            migrationBuilder.RenameTable(
                name: "Treats",
                newName: "Books");

            migrationBuilder.RenameTable(
                name: "Flavors",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "Flavoring",
                newName: "Opera");

            migrationBuilder.RenameIndex(
                name: "IX_Flavoring_TreatId",
                table: "Opera",
                newName: "IX_Opera_TreatId");

            migrationBuilder.RenameIndex(
                name: "IX_Flavoring_FlavorId",
                table: "Opera",
                newName: "IX_Opera_FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "TreatId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "FlavorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Opera",
                table: "Opera",
                column: "FlavoringId");

            migrationBuilder.AddForeignKey(
                name: "FK_Opera_Authors_FlavorId",
                table: "Opera",
                column: "FlavorId",
                principalTable: "Authors",
                principalColumn: "FlavorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Opera_Books_TreatId",
                table: "Opera",
                column: "TreatId",
                principalTable: "Books",
                principalColumn: "TreatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
