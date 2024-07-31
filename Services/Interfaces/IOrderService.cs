using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> Create(string name, int productId, int quantity, string address, string extraNote);
    }
}
