
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
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly ICarRepository repository;
		private readonly IOrderRepository orderRepository;
		private readonly ICustomerRepository customerRepository;

		public CustomersController(ICarRepository repository,ICustomerRepository customerRepository,IOrderRepository orderRepository)
		{
			this.repository = repository;
			this.customerRepository = customerRepository;
			this.orderRepository = orderRepository;
		}

		[HttpGet]
		public IEnumerable<Customer> GetCustomers([FromQuery] CustomerParameters customerParameters)
		{
			var customers = customerRepository.GetCustomers(customerParameters);
			foreach(var customer in customers)
            {
				var orders=orderRepository.GetOrders().Where(o => o.CustomerId == customer.Id.ToString());
				foreach (var order in orders)
				{
					var car = repository.GetCar(order.CarId);
					customer.Cars.Add(car);
				}
            }

			return customers;
		}

	}
}
