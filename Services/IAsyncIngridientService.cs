using RecipeBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Services
{
    public interface IAsyncIngredientService
    {
        public Task<IEnumerable<Ingredient>> GetIngredientsAsync();
        public ValueTask<Ingredient> GetIngredientByIdAsync(int? key);
        public Task AddIngredientAsync(Ingredient category);
        public IEnumerable<Ingredient> GetIngredients();
        public Ingredient GetIngredientById(int? key);
        public void AddIngredient(Ingredient category);
        public ValueTask<bool> DeleteIngredientAsync(int? key);
        public ValueTask<Ingredient> EditIngredientAsync(Ingredient category);
    }
}
