using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public enum SIZES
    {
        SMALL,
        MEDIUM,
        LARGE
    }
    public class FESize
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ID { get; set; }
        public SIZES SIZE { get; set; }
    }
}
