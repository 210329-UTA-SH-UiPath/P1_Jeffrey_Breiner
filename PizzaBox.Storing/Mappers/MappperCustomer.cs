using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperCustomer : IMapper<Customer, DBCustomer>
    {
        /// <summary>
        /// Map DBCustomer => Customer
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Customer Map(DBCustomer entity)
        {
            Customer customer = new Customer();
            customer.Name = entity.Name;
            customer.ID = entity.ID;
            return customer;
        }

        /// <summary>
        /// Map Customer => DBCustomer
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBCustomer Map(Customer model, PizzaDbContext context)
        {
            var dbCustomer = context.DBCustomers.FirstOrDefault(customer => customer.Name.Equals(model.Name));
            if (dbCustomer is not null)
            {
                return dbCustomer;
            }

            DBCustomer customer = new DBCustomer();
            customer.Name = model.Name;
            return customer;
        }
    }
}