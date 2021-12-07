using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Models
{
    public class IngredientUsage
    {
        public Ingredient Ingredient { get; set; }
        public Recipe Recipe { get; set; }
        public string Measure { get; set; }
        public string Quantity { get; set; }
    }
}
