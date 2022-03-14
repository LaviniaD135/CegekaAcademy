using academy_tema02.Models;
using academy_tema02.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace academy_tema02.Controllers
{
    [Route("api/[controller]")]
   // [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository repository;

        public OrdersController(IOrderRepository repository)
        {
            this.repository = repository;
        }

       // Get orders
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            var orders = repository.GetOrders();
            return orders;
        }

        //POST /order
        [HttpPost]
        public ActionResult<Order> CreateOrder(Order order)
        {
            order.Id=Guid.NewGuid().ToString();

            repository.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrders), new { id = order.Id }, order);


        }

    }
}
