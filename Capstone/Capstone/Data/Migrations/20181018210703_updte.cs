using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class updte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeMatch_RecipeMatch",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeMatch",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeMatch",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeMatch",
                table: "Recipes",
                column: "RecipeMatch",
                unique: true,
                filter: "[RecipeMatch] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeMatch_RecipeMatch",
                table: "Recipes",
                column: "RecipeMatch",
                principalTable: "RecipeMatch",
                principalColumn: "RecipeMatchID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_RecipeMatch_RecipeMatch",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_RecipeMatch",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeMatch",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeMatch",
                table: "Recipes",
                column: "RecipeMatch",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_RecipeMatch_RecipeMatch",
                table: "Recipes",
                column: "RecipeMatch",
                principalTable: "RecipeMatch",
                principalColumn: "RecipeMatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
