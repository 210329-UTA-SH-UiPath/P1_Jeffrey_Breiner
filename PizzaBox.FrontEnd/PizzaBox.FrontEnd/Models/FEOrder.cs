using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Models
{
    public class FEOrder
    {
        public FEOrder()
        {
            Store = new FEStore();
            Customer = new FECustomer();
            Pizza = new List<FEPizza>();
        }

        public FEStore Store { get; set; }
        public FECustomer Customer { get; set; }
        public List<FEPizza> Pizza { get; set; }
        public decimal priceTotal { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ID { get; set; }
    }
}
