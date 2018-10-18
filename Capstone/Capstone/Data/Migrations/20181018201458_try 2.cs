using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class try2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeMatchID",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "RecipeMatchID",
                table: "MealPlans",
                newName: "RecipeID");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_RecipeMatchID",
                table: "MealPlans",
                newName: "IX_MealPlans_RecipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeID",
                table: "MealPlans",
                column: "RecipeID",
                principalTable: "RecipeMatch",
                principalColumn: "RecipeMatchID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeID",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "RecipeID",
                table: "MealPlans",
                newName: "RecipeMatchID");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_RecipeID",
                table: "MealPlans",
                newName: "IX_MealPlans_RecipeMatchID");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_RecipeMatch_RecipeMatchID",
                table: "MealPlans",
                column: "RecipeMatchID",
                principalTable: "RecipeMatch",
                principalColumn: "RecipeMatchID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
