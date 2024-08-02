using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers
{
    [Authorize(Policies.IsAdmin)]
    public class IngredientController : Controller
    {
        private readonly IIngredientsService _ingredientsSvc;

        public IngredientController(IIngredientsService ingredientsSvc)
        {
            _ingredientsSvc = ingredientsSvc;
        }

        public async Task<IActionResult> AllIngredients()
        {
            var ingredients = await _ingredientsSvc.GetAllIngredients();
            return View(ingredients);
        }

        public IActionResult Create()
        {   
            return View(new Ingredient()); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ingredient ingredient) { 
            if(ModelState.IsValid)
            {
                await _ingredientsSvc.Create(ingredient);
                return RedirectToAction("AllIngredients", "Ingredient");
            }
            return View(ingredient);
        }

        public async Task<IActionResult> DetailIngredient(int id)
        {
            var ingredient = await _ingredientsSvc.Read(id);
            return View(ingredient);
        }

        public async Task<IActionResult> Edit(int id) {
            var ingredient = await _ingredientsSvc.Read(id);
            return View(ingredient);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ingredient ingredient) {
            if (ModelState.IsValid) {
                await _ingredientsSvc.Update(ingredient);
                return RedirectToAction("AllIngredients", "Ingredient");
            } 
            return View(ingredient);
            
        }
        public async Task<IActionResult> Delete(int id) {
            var ingredient = await _ingredientsSvc.Read(id);
            return View(ingredient);
        }

        public async Task <IActionResult> DeleteConfirmed(int id)
        {
            await _ingredientsSvc.Delete(id);
            return RedirectToAction("AllIngredients", "Ingredient");
        }
    }
}
