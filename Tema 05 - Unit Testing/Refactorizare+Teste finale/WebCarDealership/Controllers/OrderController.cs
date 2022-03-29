using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership.Requests;
using WebCarDealership.Service;

namespace WebCarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IEntityService entityService;
        public OrderController(IEntityService entityService)
        {
            this.entityService = entityService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OrderRequestModel model)
        {
            // Validate
            if (!ModelState.IsValid || !await entityService.IsOrderRequestModelValid(model))
            {
                return BadRequest(ModelState);
            }

            // Update offer and add order
            var order = await entityService.CreateOrder(model);
            if (order == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Adding the order failed");
            }

            return Ok(order);
        }
    }
}
