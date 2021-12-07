using Microsoft.EntityFrameworkCore;
using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Services
{
    public class RecipeService : IAsyncRecipeService
    {
        private readonly RecipeBookDBContext _db;

        public RecipeService(RecipeBookDBContext db)
        {
            _db = db;
        }
        public void AddRecipe(Recipe category)
        {
            _db.Recipes.Add(category);
            _db.SaveChanges();
        }
        public async Task AddRecipeAsync(Recipe category)
        {
            await _db.Recipes.AddAsync(category);
            await _db.SaveChangesAsync();
        }
        public IEnumerable<Recipe> GetRecipes()
        {
            return _db.Recipes;
        }
        public async Task<IEnumerable<Recipe>> GetRecipesAsync()
        {
            return await _db.Recipes.ToListAsync();
        }
        public Recipe GetRecipeById(int? key)
        {
            return _db.Recipes.Find(key);
        }
        public ValueTask<Recipe> GetRecipeByIdAsync(int? key)
        {
            return _db.Recipes.FindAsync(key);
        }
        public async ValueTask<bool> DeleteRecipeAsync(int? key)
        {
            if (key is null) return false;

            var category = await _db.Recipes.FindAsync(key);

            if (category is null) return false;

            _db.Recipes.Remove(category);
            await _db.SaveChangesAsync();

            return true;
        }
        public async ValueTask<Recipe> EditRecipeAsync(Recipe category)
        {
            _db.Recipes.Update(category);
            await _db.SaveChangesAsync();

            return category;
        }
    }
}
