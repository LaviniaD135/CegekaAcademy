using academy_tema02.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace academy_tema02.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<Order> orders = new()
        {
            new Order { Id = System.Guid.NewGuid().ToString(), CustomerId="3456",CarId="abc" },
            new Order { Id = System.Guid.NewGuid().ToString(), CustomerId = "3456", CarId = "abc" }
        };                                       

        public IEnumerable<Order> GetOrders()
        {
            return orders;
        }

        public void CreateOrder(Order order)
        {
            orders.Add(order);
        }

  
    }
}
