using System.Collections.Generic;
using System.Linq;
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
      List<Customer> customers = new List<Customer>();
      context.DBCustomers.AsEnumerable().GroupBy(customer => customer.Name).Select(customer => customer.First()).ToList().ForEach(customer =>
        customers.Add(mapperCustomer.Map(customer)));
      return customers;
    }

    public void Remove(Customer genericType)
    {
      DBCustomer customer = context.DBCustomers.ToList().Find(customer => customer.Name.Equals(genericType.Name));

      if (customer is not null)
      {
        context.DBCustomers.Remove(customer);
        context.SaveChanges();
      }
    }

    public void update(Customer existingType, Customer updatedType)
    {
      DBCustomer customer = context.DBCustomers.ToList().Find(customer => customer.Name.Equals(existingType.Name));

      if (customer is not null)
      {
        customer.Name = updatedType.Name;
        context.SaveChanges();
      }
    }
  }
}