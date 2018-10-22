using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class changetomealplanmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeID",
                table: "MealPlans");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_Recipes_RecipeID",
                table: "MealPlans",
                column: "RecipeID",
                principalTable: "Recipes",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_Recipes_RecipeID",
                table: "MealPlans");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeID",
                table: "MealPlans",
                column: "RecipeID",
                principalTable: "RecipeMatch",
                principalColumn: "RecipeMatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
