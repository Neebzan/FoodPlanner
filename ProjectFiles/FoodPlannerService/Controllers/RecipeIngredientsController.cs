using FoodPlannerService.Models;
using FoodPlannerService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeIngredientsController : ControllerBase {

        IRecipeIngredientsRepository _recipeIngredientsRepository;
        public RecipeIngredientsController(IRecipeIngredientsRepository recipeIngredientsRepository) {
            _recipeIngredientsRepository = recipeIngredientsRepository;
        }

        [HttpGet("{recipeID}")]
        public async Task<IEnumerable<RecipeIngredients>> GetIngredients(int recipeID) {
            return await _recipeIngredientsRepository.Get(recipeID);
        }

        [HttpPost]
        public async Task<RecipeIngredients> CreateRecipeIngredients(RecipeIngredients recipeIngredients) {
            return await _recipeIngredientsRepository.Create(recipeIngredients);
        }
    }
}
