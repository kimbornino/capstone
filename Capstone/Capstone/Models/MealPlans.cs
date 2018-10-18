﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class MealPlans
    {
        [Key]
        public int MealPlanID {get; set;}

        public DateTime Date { get; set; }

        public string DayOfWeek { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeID{ get; set; }
        public RecipeMatch Recipe { get; set; }
        
       public IEnumerable<Recipes> Recipes { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [Display(Name = "Search For Recipes")]
        public string SearchTerm { get; set; }

    }
}
