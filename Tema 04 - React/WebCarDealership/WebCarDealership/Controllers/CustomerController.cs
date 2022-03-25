using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;
using WebCarDealership.Requests;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CustomerController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new Customer
            {
               
                Name = model.Name,
                Email = model.Email
                
            };

            _dbContext.Customers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }

        [HttpPut("{id}")]

        public async Task<IActionResult>Put(int id,[FromBody] CustomerRequest model)
        
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id);
            if (existingCustomer==null)
            {
                return NotFound();
            }
            existingCustomer.Name=model.Name;
            existingCustomer.Email=model.Email;

   

            _dbContext.Customers.Update(existingCustomer);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), existingCustomer);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var existingCustomer = await _dbContext.Customers.FindAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            _dbContext.Customers.Remove(existingCustomer);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }
    }
}