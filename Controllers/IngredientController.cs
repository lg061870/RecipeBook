using Microsoft.AspNetCore.Mvc;
using RecipeBook.Models;
using RecipeBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IngredientBook.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IAsyncIngredientService _ingredientService;

        public IngredientController(IAsyncIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        public async Task<IActionResult> Index()
        {
            var objList = await _ingredientService.GetIngredientsAsync();
            return View(objList.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                await _ingredientService.AddIngredientAsync(ingredient);
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? key)
        {
            if (key is null || key == 0) return NotFound();

            var category = await _ingredientService.GetIngredientByIdAsync(key);

            if (category is null) return NotFound();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ingredient recipe)
        {
            if (ModelState.IsValid)
            {
                var updatedIngredient = await _ingredientService.EditIngredientAsync(recipe);
                return View(updatedIngredient);
            }

            return View(recipe);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? key)
        {
            if (key is null || key == 0) return NotFound();

            var category = await _ingredientService.GetIngredientByIdAsync(key);

            if (category is null) return NotFound();

            return View(category);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? key)
        {
            var result = await _ingredientService.DeleteIngredientAsync(key);

            if (!result)
            {
                ModelState.AddModelError(key.ToString(), "Ingredient not found. It may have been deleted elsewhere");
                return View(await _ingredientService.GetIngredientByIdAsync(key));
            }

            return RedirectToAction("Index");
        }
    }
}
