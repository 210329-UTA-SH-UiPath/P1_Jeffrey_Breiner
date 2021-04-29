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
            return context.DBOrders.Include(order => order.DBCustomer).Include(order => order.DBStore).Include(order => order.Pizzas)
              .ThenInclude(pizza => pizza.DBPlacedToppings).ThenInclude(placedTopping => placedTopping.Topping).Include(order => order.Pizzas)
              .ThenInclude(pizza => pizza.DBSize).Include(order => order.Pizzas).ThenInclude(pizza => pizza.DBCrust).Select(mapperOrder.Map).ToList();
        }

        public Order GetById(int id)
        {
            var dbOrder = context.DBOrders.Include(order => order.DBCustomer).Include(order => order.DBStore).Include(order => order.Pizzas)
              .ThenInclude(pizza => pizza.DBPlacedToppings).ThenInclude(placedTopping => placedTopping.Topping).Include(order => order.Pizzas)
              .ThenInclude(pizza => pizza.DBSize).Include(order => order.Pizzas).ThenInclude(pizza => pizza.DBCrust).FirstOrDefault(order => order.ID == id);

            if (dbOrder is null)
            {
                return null;
            }

            return mapperOrder.Map(dbOrder);
        }

        /// <summary>
        /// Creates two 
        /// </summary>
        /// <param name="genericType"></param>
        public void Remove(int id)
        {
            DBOrder order = context.DBOrders.FirstOrDefault(order => order.ID == id);
            if (order is not null)
            {
                context.Remove(order);
                context.SaveChanges();
            }
        }

        public Order Update(Order updatedType)
        {
            DBOrder dBOrder = mapperOrder.Map(updatedType, context);
            context.SaveChanges();
            return mapperOrder.Map(dBOrder);

            /*
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
            */
        }
    }
}