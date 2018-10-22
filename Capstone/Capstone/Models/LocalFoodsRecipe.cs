using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class LocalFoodRecipe
    {
        [Key]
        public int LocalFoodRecipeID { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }
        public LocalFood Food { get; set; }

        [ForeignKey("FeaturedIngredient")]
        //rename to recipe ID
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
