using CarDealership.Data;
using CarDealership.Data.Models;
using WebCarDealership.Requests;

namespace WebCarDealership.Service
{
    public class EntityService: IEntityService
    {
        private readonly IRepository repository;
        public EntityService(IRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Order> CreateOrder(OrderRequestModel model)
        {
            var offer = await repository.GetCarOfferById(model.CarOfferId);
            var dbOrder = new Order()
            {
                CarOfferId = model.CarOfferId,
                CustomerId = model.CustomerId,
                //Date = DateTime.UtcNow,
                Quantity = model.Quantity,
               // OrderAmount = model.Quantity * offer.UnitPrice
            };

            return await repository.AddOrder(dbOrder);
        }
            
        public  async Task<bool> IsOrderRequestModelValid(OrderRequestModel model)
        {
            try
            {
                var customer = await repository.GetCustomerById(model.CustomerId);
                if (customer == null)
                {
                    return false;
                }

                var offer = await repository.GetCarOfferById(model.CarOfferId);
                if (offer == null)
                {
                    return false;
                }

                if (offer.AvailableStock <= model.Quantity)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
