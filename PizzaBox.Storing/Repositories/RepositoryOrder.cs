using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
  public class RepositoryOrder : IRepository<Order>
  {
    private readonly MapperOrder mapperOrder = new MapperOrder();
    private readonly PizzaDbContext context;
    public RepositoryOrder(PizzaDbContext context)
    {
      this.context = context;
    }

    /// <summary>
    /// Maps the domain model passed into it to an entity model in context. Then saves it to the DB.
    /// </summary>
    /// <param name="genericType"></param>
    public void Add(Order genericType)
    {
      context.DBOrders.Add(mapperOrder.Map(genericType, context));
      context.SaveChanges();
    }

    /// <summary>
    /// Creates a domain model. Then creates an entity model, builds a DB query, sends it to the DB,
    /// stores the result in context's DbSet, and then maps it the domain model and returns the domain model.
    /// </summary>
    /// <returns></returns>
    public List<Order> GetList()
    {
      List<Order> orders = new List<Order>();

      context.DBOrders.Include(order => order.DBCustomer).Include(order => order.DBStore).Include(order => order.Pizzas)
        .ThenInclude(pizza => pizza.DBPlacedToppings).ThenInclude(placedTopping => placedTopping.Topping).Include(order => order.Pizzas).ThenInclude(pizza => pizza.DBSize)
        .Include(order => order.Pizzas).ThenInclude(pizza => pizza.DBCrust).ToList().ForEach(order => orders.Add(mapperOrder.Map(order)));

      return orders;
    }

    /// <summary>
    /// Creates two 
    /// </summary>
    /// <param name="genericType"></param>
    public void Remove(Order genericType)
    {
      DBOrder dbOrder = mapperOrder.Map(genericType, context);
      DBOrder order = context.DBOrders.ToList().Find(order => order.GetHashCode() == dbOrder.GetHashCode());
      if (order is not null)
      {
        context.Remove(order);
        context.SaveChanges();
      }
    }

    public void update(Order existingType, Order updatedType)
    {
      DBOrder dbOrder = mapperOrder.Map(existingType, context);
      DBOrder order = context.DBOrders.ToList().Find(order => order.GetHashCode() == dbOrder.GetHashCode());
      if (order is not null)
      {
        DBOrder updatedOrder = mapperOrder.Map(updatedType, context);
        order.DBCustomer = updatedOrder.DBCustomer;
        order.Pizzas = updatedOrder.Pizzas;
        order.DBStore = updatedOrder.DBStore;
        order.TimeStamp = updatedOrder.TimeStamp;
        order.PriceTotal = updatedOrder.PriceTotal;
        context.SaveChanges();
      }
    }
  }
}