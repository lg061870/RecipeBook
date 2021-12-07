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
    public class IngredientService : IAsyncIngredientService
    {
        private readonly RecipeBookDBContext _db;

        public IngredientService(RecipeBookDBContext db)
        {
            _db = db;
        }
        public void AddIngredient(Ingredient category)
        {
            _db.Ingredients.Add(category);
            _db.SaveChanges();
        }
        public async Task AddIngredientAsync(Ingredient category)
        {
            await _db.Ingredients.AddAsync(category);
            await _db.SaveChangesAsync();
        }
        public IEnumerable<Ingredient> GetIngredients()
        {
            return _db.Ingredients;
        }
        public async Task<IEnumerable<Ingredient>> GetIngredientsAsync()
        {
            return await _db.Ingredients.ToListAsync();
        }
        public Ingredient GetIngredientById(int? key)
        {
            return _db.Ingredients.Find(key);
        }
        public ValueTask<Ingredient> GetIngredientByIdAsync(int? key)
        {
            return _db.Ingredients.FindAsync(key);
        }
        public async ValueTask<bool> DeleteIngredientAsync(int? key)
        {
            if (key is null) return false;

            var category = await _db.Ingredients.FindAsync(key);

            if (category is null) return false;

            _db.Ingredients.Remove(category);
            await _db.SaveChangesAsync();

            return true;
        }
        public async ValueTask<Ingredient> EditIngredientAsync(Ingredient category)
        {
            _db.Ingredients.Update(category);
            await _db.SaveChangesAsync();

            return category;
        }
    }
}
