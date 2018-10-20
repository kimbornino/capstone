using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class RecipeMatch
    {
        [Key]
        public int RecipeMatchID { get; set; }

        [ForeignKey("Food")]
        public int FoodID { get; set; }
        public LocalFoods Food { get; set; }

        [ForeignKey("FeaturedIngredient")]
        public int SeasonalIngredient { get; set; }
        public Recipes FeaturedIngredient { get; set; }
    }
}
