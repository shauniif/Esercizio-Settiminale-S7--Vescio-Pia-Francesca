using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productSvc;
        private readonly DataContext _db;
        public ProductController(IProductService productSvc, DataContext db) 
        {
            _productSvc = productSvc;
            _db = db;
        }
        public async Task<IActionResult> AllProducts()
        {
            var products = await _productSvc.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var ingredients = _db.Ingredients.ToList();
            ViewBag.Ingredients = ingredients;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model, IEnumerable<int> ingredientSelected)
        {
            if (ModelState.IsValid)
            {
                await _productSvc.Create(model, ingredientSelected);
                return RedirectToAction("AllProducts", "Product");
            }
            else
            {

                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productSvc.Read(id);
            var ingredients = _db.Ingredients.ToList();
            ViewBag.Ingredients = ingredients;
            return View(product);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productSvc.Delete(id);
            return RedirectToAction("AllProducts", "Product");

        }

        public async Task<IActionResult> Edit(int id)
        {
            var ingredients = _db.Ingredients.ToList();
            ViewBag.Ingredients = ingredients;
            var product = await _productSvc.Read(id);
            var productV = new ProductViewModel
            {
                Name = product.Name,
                Price = product.Price,
                DeliveryTimeInMinutes = product.DeliveryTimeInMinutes,
            };
            ViewBag.ProductId = id;
            ViewBag.SelectedIngredients = product.Ingredients.Select(i => i.Id).ToList(); 
            return View(productV);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel productV, IEnumerable<int> ingredientSelected)
        {
            if (ModelState.IsValid)
            {
            await _productSvc.Update(id, productV, ingredientSelected);
            return RedirectToAction("AllProducts", "Product");
            }
            return View(productV);
        }

        public IActionResult SearchAdmin()
        {
            return View(); 
        }
    }
}
