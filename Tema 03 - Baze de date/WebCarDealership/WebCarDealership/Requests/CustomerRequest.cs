using CarDealership.Data.Models;
using System.ComponentModel.DataAnnotations;
namespace WebCarDealership.Requests
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }

       
    }
}
