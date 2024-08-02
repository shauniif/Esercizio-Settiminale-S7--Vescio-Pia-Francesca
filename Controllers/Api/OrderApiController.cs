using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Services.Interfaces;
using Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _orderSvc;

        public OrderApiController(IOrderService orderSvc)
        {
            _orderSvc = orderSvc;
        }


        [HttpGet]
        public async Task<ActionResult> CountOrder()
        {
            var count = await _orderSvc.CountOrderProcessed();
            return Ok(count);
        }

        [HttpGet("TotalByDay/{date}")]
        public async Task<ActionResult> TotalPayed(DateTime date)
        { 
            var total = await _orderSvc.GetTotalByDate(date);
            return Ok(total);
        }

    }
}
