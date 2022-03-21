using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }
        public Customer Customer { get; set; }
    }
}
