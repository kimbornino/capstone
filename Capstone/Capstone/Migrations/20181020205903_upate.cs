using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class upate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipesRecipeID",
                table: "LocalFoods",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocalFoods_RecipesRecipeID",
                table: "LocalFoods",
                column: "RecipesRecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalFoods_Recipes_RecipesRecipeID",
                table: "LocalFoods",
                column: "RecipesRecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalFoods_Recipes_RecipesRecipeID",
                table: "LocalFoods");

            migrationBuilder.DropIndex(
                name: "IX_LocalFoods_RecipesRecipeID",
                table: "LocalFoods");

            migrationBuilder.DropColumn(
                name: "RecipesRecipeID",
                table: "LocalFoods");
        }
    }
}
