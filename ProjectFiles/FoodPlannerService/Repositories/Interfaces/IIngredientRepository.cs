using FoodPlannerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Repositories.Interfaces {
    public interface IIngredientRepository {
        Task<IEnumerable<Ingredient>> Get();
        Task<Ingredient> Get(int id);
        Task<Ingredient> Create(Ingredient ingredient);
        Task Update(Ingredient ingredient);
        Task Delete(int id);
    }
}
