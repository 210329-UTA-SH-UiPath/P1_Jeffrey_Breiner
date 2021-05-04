using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IO.Swagger.Model
{
    public partial class Order
    {
        public virtual decimal CalculateOrderPrice()
        {
            PriceTotal = Pizza.Sum(pizza => pizza.Price);
            return Convert.ToDecimal(PriceTotal);
        }
    }
}
