using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
    public class RepositoryCustomer : IRepository<Customer>
    {
        private readonly MapperCustomer mapperCustomer = new MapperCustomer();
        private readonly PizzaDbContext context;
        public RepositoryCustomer(PizzaDbContext context)
        {
            this.context = context;
        }
        public void Add(Customer genericType)
        {
            context.DBCustomers.Add(mapperCustomer.Map(genericType, context));
            context.SaveChanges();
        }

        public List<Customer> GetList()
        {
            return context.DBCustomers.Select(mapperCustomer.Map).ToList();
        }

        public Customer GetById(int id)
        {
            var dbCustomer = context.DBCustomers.FirstOrDefault(customer => customer.ID == id);

            if (dbCustomer is null)
            {
                return null;
            }

            return mapperCustomer.Map(dbCustomer);
        }

        public void Remove(int id)
        {
            DBCustomer customer = context.DBCustomers.FirstOrDefault(customer => customer.ID == id);

            if (customer is not null)
            {
                context.DBCustomers.Remove(customer);
                context.SaveChanges();
            }
        }

        public Customer Update(Customer updatedType)
        {
            DBCustomer dBCustomer = mapperCustomer.Map(updatedType, context);
            context.SaveChanges();
            return mapperCustomer.Map(dBCustomer);
        }
    }
}