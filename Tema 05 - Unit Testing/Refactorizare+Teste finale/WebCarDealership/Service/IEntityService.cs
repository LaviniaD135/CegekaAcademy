using CarDealership.Data.Models;
using WebCarDealership.Requests;

namespace WebCarDealership.Service
{
    public interface IEntityService
    {
        Task<Order> CreateOrder(OrderRequestModel model);
        Task<bool> IsOrderRequestModelValid(OrderRequestModel model);
    }
}
