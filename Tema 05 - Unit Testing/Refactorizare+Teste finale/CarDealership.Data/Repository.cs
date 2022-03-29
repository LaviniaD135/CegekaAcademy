using CarDealership.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCarDealership;

namespace CarDealership.Data
{
    public class Repository : IRepository
    {
        private readonly DealershipDbContext context;
        public Repository(DealershipDbContext context)
        {
            this.context = context;
        }

        public async Task<CarOffer> GetCarOfferById(int id) {
            if (id == 0)
                return null;

            return await context.CarOffers.FirstOrDefaultAsync(offer => offer.Id == id);
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            if (id == 0)
                return null;

            return await context.Customers.FirstOrDefaultAsync(customer => customer.Id == id);
        }
        public async Task<Order> AddOrder(Order order)
        {
            try
            {
                var offer = await GetCarOfferById(order.CarOfferId);
                offer.AvailableStock -= order.Quantity;

                context.Orders.Add(order);
                await context.SaveChangesAsync();

                return order;
            }
            catch
            {
                return null;
            }
        }

    }
}
