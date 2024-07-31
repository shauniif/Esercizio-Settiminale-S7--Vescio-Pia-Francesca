using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Context;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.CodeAnalysis;
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

        public async Task<Order> Create(string name, int productId, int quantity, string address, string extraNote)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Name == name);
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == productId);

            var order = await _db.Orders
                        .Include(o => o.Items)
                        .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.IsProcessed);

            if (order == null)
            {
                order = new Order
                {
                    Date = DateTime.Now,
                    User = user,
                    IsProcessed = false,
                    Address = address,
                    ExtraNote = extraNote ?? " ",
                };
                _db.Orders.Add(order);
            }

            var orderItem = order.Items.FirstOrDefault(i => i.Product != null && i.Product.Id == productId);
            if (orderItem == null)
            {
                orderItem = new OrderItem
                {
                    Product = product,
                    Quantity = quantity,
                    Order = order
                };
                order.Items.Add(orderItem);
                
            }
            else
            {
                orderItem.Quantity += quantity;

            }
            order.Items.Add(orderItem);

            await _db.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            var allOrders = await _db.Orders
                                .Include(p => p.Items)
                                .ThenInclude(i => i.Product)
                                .ToListAsync();

            return allOrders;
        }

        public async Task<IEnumerable<Order>> GetMyOrder(string name)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Name == name);
            var myOrder = await _db.Orders
                                 .Include(p => p.Items)
                                 .ThenInclude(i => i.Product)
                                 .Where(p => p.User == user)
                                 .ToListAsync();
                                 
            return myOrder;
        }

        public async Task UpdateQuantity(string name, int productId, int quantity)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Name == name);
            if (user == null) throw new Exception("User not found");

            // Trova l'ordine non processato per l'utente
            var order = await _db.Orders
                                 .Include(o => o.Items)
                                 .ThenInclude(i => i.Product)
                                 .FirstOrDefaultAsync(o => o.User.Id == user.Id && !o.IsProcessed);

            var orderItem = order.Items.FirstOrDefault(i => i.Product.Id == productId);
            Console.WriteLine($"My order item {orderItem}");
            orderItem.Quantity = quantity;
           await _db.SaveChangesAsync();
        }
    }
}
