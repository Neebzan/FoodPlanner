using FoodPlannerService.Models;
using FoodPlannerService.Repositories;
using FoodPlannerService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase {
        IIngredientRepository _ingredientRepository;
        public IngredientsController(IIngredientRepository ingredientRepository) {
            _ingredientRepository = ingredientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetIngredients() {
            return await _ingredientRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredients(int id) {
            return await _ingredientRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredients ([FromBody] Ingredient ingredient) {
            var newIngredient = await _ingredientRepository.Create(ingredient);
            return CreatedAtAction(nameof(GetIngredients), new { id = newIngredient.Id }, newIngredient);
        }

        [HttpPut]
        public async Task<ActionResult<Ingredient>> PutIngredient(int id, [FromBody] Ingredient ingredient) {
            if (id != ingredient.Id) {
                return BadRequest();
            }
            await _ingredientRepository.Update(ingredient);

            return NoContent();
        }

        [HttpDelete ("{id}")]
        public async Task<ActionResult> DeleteIngredient (int id) {
            var ingredientToDelete = await _ingredientRepository.Get(id);
            if (ingredientToDelete == null) {
                return NotFound();
            }
            await _ingredientRepository.Delete(id);
            return NoContent();            
        }
    }
}
