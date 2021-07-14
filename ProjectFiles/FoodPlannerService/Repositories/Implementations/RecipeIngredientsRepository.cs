using FoodPlannerService.Models;
using FoodPlannerService.Models.Contexts;
using FoodPlannerService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace FoodPlannerService.Repositories.Implementations {
    public class RecipeIngredientsRepository : IRecipeIngredientsRepository {

        readonly RecipeIngredientsContext _context;

        public RecipeIngredientsRepository(RecipeIngredientsContext context) {
            _context = context;
        }

        public async Task<RecipeIngredients> Create(RecipeIngredients recipeIngredients) {
            await _context.RecipeIngredients.AddAsync(recipeIngredients);
            await _context.SaveChangesAsync();
            return recipeIngredients;
        }

        public async Task<IEnumerable<RecipeIngredients>> Get(int recipeID) {
            var query = from recipeIngredients in (await _context.RecipeIngredients.ToListAsync())
                        where recipeIngredients.RecipeID == recipeID
                        select recipeIngredients;

            return query.ToList();
        }
    }
}
