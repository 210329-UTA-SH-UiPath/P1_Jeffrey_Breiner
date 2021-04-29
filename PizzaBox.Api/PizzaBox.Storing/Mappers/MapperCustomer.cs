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
        public DBCustomer Map(Customer model, PizzaDbContext context, bool update = false)
        {
            DBCustomer dbCustomer = context.DBCustomers.FirstOrDefault(customer => customer.ID == model.ID) ?? new DBCustomer();
            if (dbCustomer.ID != 0 && !update)
            {
                return dbCustomer;
            }

            dbCustomer.Name = model.Name;

            if (dbCustomer.ID == 0)
            {
                context.DBCustomers.Add(dbCustomer);
            }
            return dbCustomer;
        }
    }
}