using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class LocalFoods
    {

        [Key]
        public int FoodID { get; set; }

        [Display(Name = "Food")]
        public string FoodName { get; set; }

        [Display(Name = "Start of Season")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End of Season")]
        public DateTime EndDate { get; set; }

        public string FoodImage { get; set; }

        [Display(Name = "Nutritional Information"]
        public string NutritionalInfo { get; set; }
        
    }
}
