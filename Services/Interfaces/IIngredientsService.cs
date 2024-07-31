using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IIngredientsService
    {
        Task<Ingredient> Create(Ingredient entity);

        Task<Ingredient> Read(int id);
        Task<Ingredient> Update(Ingredient entity);

        Task<Ingredient> Delete(int id);
        Task<IEnumerable<Ingredient>> GetAllIngredients();
    }
}
