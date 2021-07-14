using FoodPlannerService.Models;
using FoodPlannerService.Repositories;
using FoodPlannerService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase {
        IRecipeRepository _recipeRepository;
        public RecipesController(IRecipeRepository recipesRepository) {
            _recipeRepository = recipesRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Recipe>> GetRecipes() {
            return await _recipeRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipes(int id) {
            return await _recipeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipes([FromBody] Recipe recipe) {
            var newRecipe = await _recipeRepository.Create(recipe);
            return CreatedAtAction(nameof(GetRecipes), new { id = newRecipe.Id }, newRecipe);
        }

        [HttpPut]
        public async Task<ActionResult<Recipe>> PutRecipe(int id, [FromBody] Recipe recipe) {
            if (id != recipe.Id) {
                return BadRequest();
            }
            await _recipeRepository.Update(recipe);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipe(int id) {
            var recipeToDelete = await _recipeRepository.Get(id);
            if (recipeToDelete == null) {
                return NotFound();
            }
            await _recipeRepository.Delete(id);
            return NoContent();
        }
    }
}
