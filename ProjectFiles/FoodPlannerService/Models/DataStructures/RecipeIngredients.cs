using FoodPlannerService.Models.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerService.Models {
    public class RecipeIngredients {
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Amount { get; set; }
    }
}
