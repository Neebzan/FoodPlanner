using FoodPlannerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Repositories.Interfaces {
    public interface IRecipeIngredientsRepository {
        Task<IEnumerable<RecipeIngredients>> Get(int recipeID);
        Task<RecipeIngredients> Create(RecipeIngredients recipeIngredients);
    }
}
