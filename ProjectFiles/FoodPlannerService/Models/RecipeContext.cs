using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Models {
    public class RecipeContext : DbContext {
        public RecipeContext (DbContextOptions<RecipeContext> options) : base(options) {
            Database.EnsureCreated();
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
