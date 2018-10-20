using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Capstone.Models.Recipes> Recipes { get; set; }
        public DbSet<Capstone.Models.LocalFoods> LocalFoods { get; set; }
        public DbSet<Capstone.Models.MealPlans> MealPlans { get; set; }
        public DbSet<Capstone.Models.MessageBoard> MessageBoard { get; set; }
        public DbSet<Capstone.Models.RecipeMatch> RecipeMatch { get; set; }
    }
}
