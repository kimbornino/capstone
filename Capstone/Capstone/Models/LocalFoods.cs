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

        public string FoodName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string FoodImage { get; set; }

        public string NutritionalInfo { get; set; }
        
    }
}
