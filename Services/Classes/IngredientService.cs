using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Classes
{
    public class IngredientService : IIngredientsService
    {
        private readonly DataContext _db;

        public IngredientService(DataContext db) { 
        _db = db;
        }
        public async Task<Ingredient> Create(Ingredient entity)
        {   try
            {
                _db.Ingredients.Add(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex) {
                throw new Exception("Ingredients not created", ex);
            }
            
        }

        public async Task<Ingredient> Delete(int id)
        { try
            {
                var ingredient = await Read(id);
                 _db.Ingredients.Remove(ingredient);
                await _db.SaveChangesAsync();
                return ingredient;
            }
            catch (Exception ex) {
                throw new Exception("Ingredients not found", ex);
            }
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredients()
        {   try
            {
            return await _db.Ingredients.ToListAsync();
            } catch(Exception ex) 
            {
                throw new Exception("Ingredients not found", ex);
            }
        }

        public async Task<Ingredient> Read(int id)
        {
            try
            {
                var ingredient = await _db.Ingredients.SingleOrDefaultAsync(i => i.Id == id);
                
                return ingredient;
            }
            catch (Exception ex)
            {
                throw new Exception("Ingredient not found", ex);

            }
        }



        public async Task<Ingredient> Update(Ingredient entity)
        { try
            {
                var ingredient = await Read(entity.Id);
                ingredient.Name = entity.Name;
                _db.Update(ingredient);
               await _db.SaveChangesAsync();
                return ingredient;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ingredient not updated", ex);
            }
          
        }
    }
}
