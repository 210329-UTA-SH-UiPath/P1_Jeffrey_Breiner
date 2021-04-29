using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class NewYorkStore : AStore
    {
        /// <summary>
        /// 
        /// </summary>
        public NewYorkStore()
        {
            Name = "New York Store";
            STORE = STORES.NEWYORK;
        }
    }
}