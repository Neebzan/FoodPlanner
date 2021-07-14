using FoodPlannerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Repositories.Interfaces {
    public interface IRecipeRepository {

        Task<IEnumerable<Recipe>> Get();
        Task<Recipe> Get(int id);
        Task<Recipe> Create(Recipe recipe);
        Task Update(Recipe recipe);
        Task Delete(int id);

    }
}
