using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderSvc;

        public OrderController(IOrderService orderSvc)
        {
            _orderSvc = orderSvc;
        }
        public async Task<IActionResult> AddProduct(string name, int productId, int quantity, string address, string extraNote)
        {
            await _orderSvc.Create(name, productId, quantity, address, extraNote);
            return RedirectToAction("AllProduct","Product");
        }
    }
}
