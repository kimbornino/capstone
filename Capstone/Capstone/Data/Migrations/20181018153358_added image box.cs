using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class addedimagebox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "LocalFoods",
                columns: table => new
                {
                    FoodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    FoodImage = table.Column<string>(nullable: true),
                    NutritionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalFoods", x => x.FoodID);
                });

            migrationBuilder.CreateTable(
                name: "RecipeMatch",
                columns: table => new
                {
                    RecipeMatchID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FoodID = table.Column<int>(nullable: false),
                    FeaturedIngredient = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeMatch", x => x.RecipeMatchID);
                    table.ForeignKey(
                        name: "FK_RecipeMatch_LocalFoods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "LocalFoods",
                        principalColumn: "FoodID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MealPlans",
                columns: table => new
                {
                    MealPlanID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<string>(nullable: true),
                    RecipeMatchID = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlans", x => x.MealPlanID);
                    table.ForeignKey(
                        name: "FK_MealPlans_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlans_RecipeMatch_RecipeMatchID",
                        column: x => x.RecipeMatchID,
                        principalTable: "RecipeMatch",
                        principalColumn: "RecipeMatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Ingreients = table.Column<string>(nullable: true),
                    RecipeMatch = table.Column<int>(nullable: false),
                    Directions = table.Column<string>(nullable: true),
                    Servings = table.Column<string>(nullable: true),
                    NutritionalInfo = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    MealPlansMealPlanID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_Recipes_MealPlans_MealPlansMealPlanID",
                        column: x => x.MealPlansMealPlanID,
                        principalTable: "MealPlans",
                        principalColumn: "MealPlanID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_RecipeMatch_RecipeMatch",
                        column: x => x.RecipeMatch,
                        principalTable: "RecipeMatch",
                        principalColumn: "RecipeMatchID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_ApplicationUserId",
                table: "MealPlans",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlans_RecipeMatchID",
                table: "MealPlans",
                column: "RecipeMatchID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeMatch_FoodID",
                table: "RecipeMatch",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_MealPlansMealPlanID",
                table: "Recipes",
                column: "MealPlansMealPlanID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_RecipeMatch",
                table: "Recipes",
                column: "RecipeMatch",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "MealPlans");

            migrationBuilder.DropTable(
                name: "RecipeMatch");

            migrationBuilder.DropTable(
                name: "LocalFoods");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
