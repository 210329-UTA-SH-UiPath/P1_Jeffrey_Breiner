using System.Collections.Generic;
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
            entity.Pizzas.ForEach(pizza => pizzas.Add(mapperPizza.Map(pizza)));

            order.Pizza = pizzas;
            if (entity.PriceTotal.HasValue)
            {
                order.priceTotal = entity.PriceTotal.Value;
            }

            order.Store = mapperStore.Map(entity.DBStore);
            order.TimeStamp = entity.TimeStamp;

            return order;
        }

        /// <summary>
        /// Map Order => DBOrder
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBOrder Map(Order model, PizzaDbContext context)
        {
            DBOrder order = new DBOrder();
            order.DBCustomer = mapperCustomer.Map(model.Customer, context);

            List<DBPizza> pizzas = new List<DBPizza>();
            model.Pizza.ForEach(pizza => pizzas.Add(mapperPizza.Map(pizza, context)));

            order.Pizzas = pizzas;
            order.DBStore = mapperStore.Map(model.Store, context);
            order.PriceTotal = model.CalculateOrderPrice();
            order.TimeStamp = System.DateTime.Now;

            return order;
        }
    }
}