using academy_tema02.Models;
using System;
using System.Collections.Generic;

namespace academy_tema02.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers(CustomerParameters customerParameters);
    }
}