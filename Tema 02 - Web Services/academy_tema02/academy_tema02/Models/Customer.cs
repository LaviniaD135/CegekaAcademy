using System;
using System.Collections.Generic;

namespace academy_tema02.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
        public Customer()
        { 
            Cars = new List<Car>();
        }
    }
}
