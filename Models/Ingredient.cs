using System.Collections.Generic;

namespace RecipeBook.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Origin { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<IngredientUsage> IngredientUsages { get; set; }
    }
}
