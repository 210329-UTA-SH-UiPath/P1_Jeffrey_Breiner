using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public class SalesReport
    {
        public string Item { get; set; }
        public int Quantity { get; set; }
        public double Revenue { get; set; }
        public IEnumerable<SalesReport> Pizzas { get; internal set; }
    }
}
