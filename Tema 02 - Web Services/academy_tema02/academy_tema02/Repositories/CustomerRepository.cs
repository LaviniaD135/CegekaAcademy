using academy_tema02.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace academy_tema02.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> customers = new()
        {
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Customer1", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Customer2", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Customer3", Cars = { } }
        };                                           
        public IEnumerable<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
