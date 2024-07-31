using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _db;

        public OrderService(DataContext db)
        {
            _db = db;
        }

        public Task<Order> Create(string name, int productId, int quantity, string address, string extraNote)
        {
            throw new NotImplementedException();
        }
    }
}
