using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Classes
{
    public class ProductService : IProductService
    {
        private readonly DataContext _db;

        public ProductService(DataContext db) { 
            _db = db;
        }

        private string ConvertImage(IFormFile image) {

            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.CopyTo(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();
                string base64String = Convert.ToBase64String(fileBytes);
                string urlImg = $"data:image/jpeg;base64,{base64String}";
                return urlImg;
            }
        }
       
        public async Task<Product> Create(ProductViewModel entity, IEnumerable<int> ingredientSelected)
        { try
            {
                var product = new Product
                {
                    Name = entity.Name,
                    Price = entity.Price,
                    DeliveryTimeInMinutes = entity.DeliveryTimeInMinutes,
                    Image = ConvertImage(entity.Image),
                };
                var ingredients = await _db.Ingredients
                                  .Where(i => ingredientSelected.Contains(i.Id))
                                  .ToListAsync();

                foreach (var ingredient in ingredients)
                {
                    product.Ingredients.Add(ingredient);
                }
                _db.Products.Add(product);
                await _db.SaveChangesAsync();
                return product;
            }
            catch (Exception ex) {
                throw new Exception("Product not created", ex);
            }
            
        }

        public async Task<Product> Delete(int id)
        {
            try
            {
                var product = await Read(id);
                _db.Remove(product);
                await _db.SaveChangesAsync();
                return product;
            }
            catch (Exception ex) {
                throw new Exception("Product not deleted", ex);
            }
            
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {   
                var product = await _db.Products
                    .Include(p => p.Ingredients).ToListAsync();
                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Product not found", ex);
            }
            
            
        }

        public async Task<Product> Read(int id)
        {
            try
            {
                var product = await _db.Products
                    .Include(p => p.Ingredients)
                    .SingleOrDefaultAsync(i => i.Id == id);

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Ingredient not found", ex);

            }
        }
        public async Task<Product> Update(int id, ProductViewModel entity, IEnumerable<int> ingredientSelected)
        { try
            {
                var product = await Read(id);
                product.Name = entity.Name;
                product.Price = entity.Price;
                product.DeliveryTimeInMinutes = entity.DeliveryTimeInMinutes;
                product.Image = ConvertImage(entity.Image);

                var ingredients = await _db.Ingredients
                                  .Where(i => ingredientSelected.Contains(i.Id))
                                  .ToListAsync();
                product.Ingredients = ingredients;
                _db.Products.Update(product);
                await _db.SaveChangesAsync();
                return product;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ingredient not found", ex);
            }

        }
    }
}
