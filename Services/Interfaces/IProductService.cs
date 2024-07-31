using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IProductService 
    {
        Task<Product> Create(ProductViewModel entity, IEnumerable<int> ingredientSelected);

        Task<Product> Read(int id);
        Task<Product> Update(int id, ProductViewModel entity, IEnumerable<int> ingredientSelected);

        Task<Product> Delete(int id);
        Task<IEnumerable<Product>> GetAllProducts();

    }
}
