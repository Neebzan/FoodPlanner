using FoodPlannerService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Repositories {
    public class IngredientRepository : IIngredientRepository {
        private readonly IngredientContext _context;

        public IngredientRepository(IngredientContext context) {
            _context = context;
        }

        public async Task<Ingredient> Create(Ingredient ingredient) {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return ingredient;
        }

        public async Task Delete(int id) {

            var ingredientToDelete = await _context.Ingredients.FindAsync(id);
            _context.Ingredients.Remove(ingredientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ingredient>> Get() {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredient> Get(int id) {
            return await _context.Ingredients.FindAsync(id);
        }

        public async Task Update(Ingredient ingredient) {
            _context.Entry(ingredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
