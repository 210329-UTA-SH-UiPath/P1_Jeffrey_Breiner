using IO.Swagger.Model;
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
            Store = new AStore();
            Customer = new FECustomer();
            Pizza = new List<APizza>();
        }

        public AStore Store { get; set; }
        public FECustomer Customer { get; set; }
        public List<APizza> Pizza { get; set; }
        public decimal priceTotal { get; set; }
        public DateTime TimeStamp { get; set; }
        public int ID { get; set; }
    }
}
