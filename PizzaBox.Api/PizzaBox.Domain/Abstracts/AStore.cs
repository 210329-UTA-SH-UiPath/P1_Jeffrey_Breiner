using System.Xml.Serialization;
using PizzaBox.Domain.Models;

namespace PizzaBox.Domain.Abstracts
{
    /// <summary>
    /// Enum containing all stores.
    /// </summary>
    public enum STORES
    {
        NEWYORK,
        CHICAGO
    }

    /// <summary>
    /// Represents the Store Abstract Class
    /// </summary>
    public class AStore
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public STORES STORE { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AStore()
        {
            ID = -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}