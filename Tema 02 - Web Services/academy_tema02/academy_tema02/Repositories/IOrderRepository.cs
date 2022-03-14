using academy_tema02.Models;
using System;
using System.Collections.Generic;

namespace academy_tema02.Repositories
{
    public interface IOrderRepository
    {
       
        IEnumerable<Order> GetOrders();
        void CreateOrder(Order order);
      
    }
}