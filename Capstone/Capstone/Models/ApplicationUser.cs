using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        [NotMapped]
        public bool IsCustomer { get; set; }
    }
}
