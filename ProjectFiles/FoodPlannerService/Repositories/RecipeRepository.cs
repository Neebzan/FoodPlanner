using FoodPlannerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Repositories {
    public class RecipeRepository : IRecipeRepository {
        readonly RecipeContext _context = null;

        public RecipeRepository(RecipeContext context) {
            _context = context;
        }

        public async Task<Recipe> Create(Recipe recipe) {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }
        public async Task<IEnumerable<Recipe>> Get() {
            return await _context.Recipes.ToListAsync();
        }

        public async Task Delete(int id) {
            Recipe toDelete =await  _context.Recipes.FindAsync(id);
            _context.Recipes.Remove(toDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe> Get(int id) {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task Update(Recipe recipe) {
            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
