using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public enum CRUSTS
    {
        DEEPDISH,
        STANDARD,
        STUFFED,
        THIN
    }
    public class FECrust
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ID { get; set; }
        public CRUSTS CRUST { get; set; }
    }
}
