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
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Dalach Alfredas", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Mundi Blaghorodna", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Hankin Galvao", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Julia Yasmin", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Hizkiah Khamisi", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Samantha Long", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Abraham Laura", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Victoire Henri", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Fabrice Lohan", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Nadia Natividad", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Nicholas Juanma", Cars = { } },
            new Customer { Id = System.Guid.NewGuid().ToString(), Name = "Honorine Kilian", Cars = { } }

        };                                           
        public IEnumerable<Customer> GetCustomers(CustomerParameters customerParameters)
        {
          return customers
        .Where(c => c.Name.Contains("H")||c.Name.Contains("h"))
        .Skip((customerParameters.PageNumber - 1) * customerParameters.PageSize)
        .Take(customerParameters.PageSize)
        .ToList();
        }
    }
}
