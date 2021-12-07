using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Instructions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<IngredientUsage> IngredientUsages { get; set; }
    }
}
