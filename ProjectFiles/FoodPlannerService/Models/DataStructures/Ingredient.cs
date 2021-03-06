using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public IList<RecipeIngredients> RecipeIngredients { get; set; }
    }
}
