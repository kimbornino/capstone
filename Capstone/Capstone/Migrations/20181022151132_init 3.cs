using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalFoods_Recipes_RecipesRecipeID",
                table: "LocalFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMatch_LocalFoods_FoodID",
                table: "RecipeMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMatch_Recipes_SeasonalIngredient",
                table: "RecipeMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_MealPlans_MealPlansMealPlanID",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_MealPlansMealPlanID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "MealPlansMealPlanID",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SearchTerm",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "SeasonalIngredient",
                table: "RecipeMatch",
                newName: "RecipeID");

            migrationBuilder.RenameColumn(
                name: "FoodID",
                table: "RecipeMatch",
                newName: "LocalFoodID");

            migrationBuilder.RenameColumn(
                name: "RecipeMatchID",
                table: "RecipeMatch",
                newName: "LocalFoodRecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeMatch_SeasonalIngredient",
                table: "RecipeMatch",
                newName: "IX_RecipeMatch_RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeMatch_FoodID",
                table: "RecipeMatch",
                newName: "IX_RecipeMatch_LocalFoodID");

            migrationBuilder.RenameColumn(
                name: "RecipesRecipeID",
                table: "LocalFoods",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_LocalFoods_RecipesRecipeID",
                table: "LocalFoods",
                newName: "IX_LocalFoods_RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalFoods_Recipes_RecipeID",
                table: "LocalFoods",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMatch_LocalFoods_LocalFoodID",
                table: "RecipeMatch",
                column: "LocalFoodID",
                principalTable: "LocalFoods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMatch_Recipes_RecipeID",
                table: "RecipeMatch",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LocalFoods_Recipes_RecipeID",
                table: "LocalFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMatch_LocalFoods_LocalFoodID",
                table: "RecipeMatch");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipeMatch_Recipes_RecipeID",
                table: "RecipeMatch");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "RecipeMatch",
                newName: "SeasonalIngredient");

            migrationBuilder.RenameColumn(
                name: "LocalFoodID",
                table: "RecipeMatch",
                newName: "FoodID");

            migrationBuilder.RenameColumn(
                name: "LocalFoodRecipeID",
                table: "RecipeMatch",
                newName: "RecipeMatchID");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeMatch_RecipeID",
                table: "RecipeMatch",
                newName: "IX_RecipeMatch_SeasonalIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_RecipeMatch_LocalFoodID",
                table: "RecipeMatch",
                newName: "IX_RecipeMatch_FoodID");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "LocalFoods",
                newName: "RecipesRecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_LocalFoods_RecipeID",
                table: "LocalFoods",
                newName: "IX_LocalFoods_RecipesRecipeID");

            migrationBuilder.AddColumn<int>(
                name: "MealPlansMealPlanID",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SearchTerm",
                table: "MealPlans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealPlansMealPlanID",
                table: "Recipes",
                column: "MealPlansMealPlanID");

            migrationBuilder.AddForeignKey(
                name: "FK_LocalFoods_Recipes_RecipesRecipeID",
                table: "LocalFoods",
                column: "RecipesRecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMatch_LocalFoods_FoodID",
                table: "RecipeMatch",
                column: "FoodID",
                principalTable: "LocalFoods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeMatch_Recipes_SeasonalIngredient",
                table: "RecipeMatch",
                column: "SeasonalIngredient",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_MealPlans_MealPlansMealPlanID",
                table: "Recipes",
                column: "MealPlansMealPlanID",
                principalTable: "MealPlans",
                principalColumn: "MealPlanID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
