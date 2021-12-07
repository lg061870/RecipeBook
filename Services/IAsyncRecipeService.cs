using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Services
{
    public interface IAsyncRecipeService
    {
        public Task<IEnumerable<Recipe>> GetRecipesAsync();
        public ValueTask<Recipe> GetRecipeByIdAsync(int? key);
        public Task AddRecipeAsync(Recipe category);
        public IEnumerable<Recipe> GetRecipes();
        public Recipe GetRecipeById(int? key);
        public void AddRecipe(Recipe category);
        public ValueTask<bool> DeleteRecipeAsync(int? key);
        public ValueTask<Recipe> EditRecipeAsync(Recipe category);
    }
}
