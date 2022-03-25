using System.Threading.Tasks;
using CarDealership.Data;
using CarDealership.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebCarDealership;

namespace CarDealership.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarOfferController : ControllerBase
    {
        private readonly DealershipDbContext _dbContext;

        public CarOfferController(DealershipDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var offers = await _dbContext.CarOffers.ToListAsync();
            return Ok(offers);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarOfferRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbModel = new CarOffer
            {
                Make = model.Make,
                Model = model.Model,
                AvailableStock = model.AvailableStock,
                DiscountPercentage = model.DiscountPercentage,
                UnitPrice = model.UnitPrice,
                Image = model.Image ?? string.Empty
            };

            _dbContext.CarOffers.Add(dbModel);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), dbModel);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(int id, [FromBody] CarOfferRequestModel model)

        {
            var existingOffer = await _dbContext.CarOffers.FindAsync(id);
            if (existingOffer == null)
            {
                return NotFound();
            }
            existingOffer.Make = model.Make;
            existingOffer.Model = model.Model;
            existingOffer.AvailableStock = model.AvailableStock;
            existingOffer.UnitPrice = model.UnitPrice;
            existingOffer.DiscountPercentage = model.DiscountPercentage;
            existingOffer.Image = model.Image;


            _dbContext.CarOffers.Update(existingOffer);

            await _dbContext.SaveChangesAsync();

            return Created(Request.GetDisplayUrl(), existingOffer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingOffer = await _dbContext.CarOffers.FindAsync(id);
            if (existingOffer == null)
            {
                return NotFound();
            }

            _dbContext.CarOffers.Remove(existingOffer);
            await _dbContext.SaveChangesAsync();
            return NoContent();

        }
    }
}