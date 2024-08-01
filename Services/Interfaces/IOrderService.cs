using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Create(string name, int productId, int quantity, string address, string extraNote);

        Task<IEnumerable<Order>> GetMyOrder(string name);

        Task<IEnumerable<Order>> GetAllOrders();

        Task UpdateQuantity(string name, int productId, int quantity);

        Task ChangeIsProcessed(int orderId);

        Task<int> CountOrderProcessed();

        Task<decimal> GetTotalByDate(DateTime date);

    }
}
