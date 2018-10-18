using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Recipes
    {
        [Key]
        public int RecipeID { get; set; }

        public string Name { get; set; }
        //should be drop down main course, side dish, drink, dessert
        public string Category { get; set; }

        public string Ingreients { get; set; }

        [ForeignKey("KeyIngredient")]
        [Display(Name = "Seasonal Ingredient")]
        public int? RecipeMatch {get;set;}
        public RecipeMatch KeyIngredient { get; set; }
        
        public string Directions { get; set; }

        public string Servings { get; set; }

        [Display(Name = "Ingredients")]
        public string NutritionalInfo { get; set; }

        public string Image { get; set; }
       
    }
}
