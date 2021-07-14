using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Models.Contexts {
    public class RecipeIngredientsContext : DbContext {
        public RecipeIngredientsContext(DbContextOptions<RecipeIngredientsContext> options) : base(options) {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<RecipeIngredients>()
                .HasKey(ri => new { ri.RecipeID, ri.IngredientID });
            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(ri => ri.Recipe)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeID);
            modelBuilder.Entity<RecipeIngredients>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientID);
        }


        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
    }
}
