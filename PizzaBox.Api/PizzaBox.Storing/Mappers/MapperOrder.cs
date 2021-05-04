using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperOrder : IMapper<Order, DBOrder>
    {
        private MapperCustomer mapperCustomer = new MapperCustomer();
        private MapperPizza mapperPizza = new MapperPizza();
        private MapperStore mapperStore = new MapperStore();

        /// <summary>
        /// Map DBOrder => Order
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Order Map(DBOrder entity)
        {
            Order order = new Order();
            order.Customer = mapperCustomer.Map(entity.DBCustomer);
            List<APizza> pizzas = new List<APizza>();
            entity.DBPizzas.ToList().ForEach(pizza => pizzas.Add(mapperPizza.Map(pizza)));

            order.Pizza = pizzas;
            order.Store = mapperStore.Map(entity.DBStore);
            order.TimeStamp = entity.TimeStamp;
            order.CalculateOrderPrice();
            order.ID = entity.ID;

            return order;
        }

        /// <summary>
        /// Map Order => DBOrder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBOrder Map(Order model, PizzaDbContext context, bool update = false)
        {
            DBOrder dbOrder = context.DBOrders.Include(order => order.DBCustomer).Include(order => order.DBStore)
                .Include(order => order.DBPizzas).ThenInclude(pizza => pizza.DBPlacedToppings).ThenInclude(placedTopping => placedTopping.Topping)
                .Include(order => order.DBPizzas).ThenInclude(pizza => pizza.DBSize).Include(order => order.DBPizzas)
                .ThenInclude(pizza => pizza.DBCrust).FirstOrDefault(order => order.ID == model.ID) ?? new DBOrder();

            if (dbOrder.ID != 0 && !update)
            {
                return dbOrder;
            }

            dbOrder.DBCustomer = mapperCustomer.Map(model.Customer, context, update);
            dbOrder.DBPizzas.Clear();

            foreach (APizza pizza in model.Pizza)
            {
                var mappedPizza = mapperPizza.Map(pizza, context, update);
                dbOrder.DBPizzas.Add(mappedPizza);
            }

            dbOrder.DBStore = mapperStore.Map(model.Store, context, update);
            dbOrder.PriceTotal = model.priceTotal;
            dbOrder.TimeStamp = DateTime.Now;

            if (dbOrder.ID == 0)
            {
                context.DBOrders.Add(dbOrder);
            }
            return dbOrder;
        }
    }
}