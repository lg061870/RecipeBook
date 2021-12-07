using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RecipeBook.Data;
using RecipeBook.Models;
using RecipeBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBook.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IAsyncRecipeService _recipeService;

        public RecipeController(IAsyncRecipeService recipeService)
        {
            _recipeService = recipeService;
        }
        public async Task<IActionResult> Index()
        {
            var objList = await _recipeService.GetRecipesAsync();
            return View(objList.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                await _recipeService.AddRecipeAsync(recipe);
                return RedirectToAction("Index");
            }

            return View(recipe);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? key)
        {
            if (key is null || key == 0) return NotFound();

            var category = await _recipeService.GetRecipeByIdAsync(key);

            if (category is null) return NotFound();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                var updatedRecipe = await _recipeService.EditRecipeAsync(recipe);
                return View(updatedRecipe);
            }

            return View(recipe);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? key)
        {
            if (key is null || key == 0) return NotFound();

            var category = await _recipeService.GetRecipeByIdAsync(key);

            if (category is null) return NotFound();

            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? key)
        {
            var result = await _recipeService.DeleteRecipeAsync(key);

            if (!result)
            {
                ModelState.AddModelError(key.ToString(), "Category not found. It may have been deleted elsewhere");
                return View(await _recipeService.GetRecipeByIdAsync(key));
            }

            return RedirectToAction("Index");
        }
    }
}
