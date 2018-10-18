using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class movedthesearchboxtoaviewonmealPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchTerm",
                table: "LocalFoods");

            migrationBuilder.AddColumn<string>(
                name: "SearchTerm",
                table: "MealPlans",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SearchTerm",
                table: "MealPlans");

            migrationBuilder.AddColumn<string>(
                name: "SearchTerm",
                table: "LocalFoods",
                nullable: true);
        }
    }
}
