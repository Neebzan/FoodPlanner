using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Models {
    public class Recipe {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IList<RecipeIngredients> RecipeIngredients{ get; set; }

    }
}
