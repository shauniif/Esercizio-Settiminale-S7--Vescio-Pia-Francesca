using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers
{
    [Authorize] 
    
    public class OrderController : Controller
    {
        private readonly IOrderService _orderSvc;

        public OrderController(IOrderService orderSvc)
        {
            _orderSvc = orderSvc;
        }

        [HttpPost]

        public async Task<IActionResult> AddProduct(string name, int productId, int quantity, string address, string extraNote)
        {
            await _orderSvc.Create(name, productId, quantity, address, extraNote);
            return RedirectToAction("AllProducts","Product");
        }

        public async Task<IActionResult> MyOrder()
        {
            string name = User.Identity.Name;
           var myOrder = await _orderSvc.GetMyOrder(name);
            return View(myOrder);
        }

        [Authorize(Policies.IsAdmin)]
        public async Task<IActionResult> AllOrders()
        {
            var myOrder = await _orderSvc.GetAllOrders();
            return View(myOrder);
        }

        public async Task<IActionResult> UpdateQuantity(int productId, int quantity)
        {
            var name = User.Identity.Name;
            await _orderSvc.UpdateQuantity(name, productId, quantity);
            return RedirectToAction("MyOrder", "Order");
        }

        [Authorize(Policies.IsAdmin)]
        public async Task<IActionResult> ChangeIsProcessed(int orderId)
        {
            await _orderSvc.ChangeIsProcessed(orderId);
            return RedirectToAction("AllOrders", "Order");
        }

        
        public async Task<IActionResult> Delete(int orderId)
        {
            await _orderSvc.Delete(orderId);
            return RedirectToAction("MyOrder", "Order");
        }

        [Authorize(Policies.IsAdmin)]
        public IActionResult SearchAdmin()
        {
            return View();
        }
    }
}
