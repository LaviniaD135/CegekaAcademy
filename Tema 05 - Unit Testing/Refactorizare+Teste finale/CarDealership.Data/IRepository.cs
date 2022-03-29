using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data
{
    public interface IRepository
    {
        Task<CarOffer> GetCarOfferById(int id);
        Task<Customer> GetCustomerById(int id);
        Task<Order> AddOrder(Order order);
    }
}
