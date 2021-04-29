using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperPizza : IMapper<APizza, DBPizza>
    {
        private MapperCrust mapperCrust = new MapperCrust();
        private MapperSize mapperSize = new MapperSize();
        private MapperTopping mapperTopping = new MapperTopping();

        /// <summary>
        /// Map DBPizza => APizza
        /// Uses enum to determine which crust class to return.
        /// Note: premade pizza classes have constructors to set all variables properly.
        /// Therefore, they do not need any data tobe passed innto them.
        /// Custom pizza however only has 1 constructor that requires crust, size, and toppings 
        /// to be passed into them.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public APizza Map(DBPizza entity)
        {
            APizza pizza;

            switch (entity.PIZZA)
            {
                case PIZZAS.CUSTOM:
                    ACrust crust = mapperCrust.Map(entity.DBCrust);
                    ASize size = mapperSize.Map(entity.DBSize);
                    List<ATopping> toppings = new List<ATopping>();
                    entity.DBPlacedToppings.ToList().ForEach(placedTopping => toppings.Add(mapperTopping.Map(placedTopping.Topping)));

                    pizza = new CustomPizza(crust, size, toppings);
                    break;
                case PIZZAS.HAWAIIAN:
                    pizza = new HawaiianPizza();
                    break;
                case PIZZAS.MEAT:
                    pizza = new MeatPizza();
                    break;
                case PIZZAS.VEGAN:
                    pizza = new VeganPizza();
                    break;
                default:
                    throw new ArgumentException("Size not recognized. Size could not be mapped properly");
            }

            pizza.CalculatePrice();
            pizza.ID = entity.ID;
            return pizza;
        }

        /// <summary>
        /// Map DBPizza => DBPizza
        /// Sets enum bassed off what pizza class was passed into it.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBPizza Map(APizza model, PizzaDbContext context, bool update = false)
        {
            DBPizza dbPizza = context.DBPizzas.Include(pizza => pizza.DBCrust).Include(pizza => pizza.DBSize)
                .Include(pizza => pizza.DBPlacedToppings).ThenInclude(placedTopping => placedTopping.Topping)
                .FirstOrDefault(pizza => pizza.ID == model.ID) ?? new DBPizza();

            if (dbPizza.ID != 0 && !update)
            {
                return dbPizza;
            }
            dbPizza.PIZZA = model.PIZZA;
            dbPizza.DBCrust = mapperCrust.Map(model.Crust, context, update);
            dbPizza.DBSize = mapperSize.Map(model.Size, context, update);
            List<DBTopping> mappedToppings = new List<DBTopping>();
            model.Toppings.ForEach(t => mappedToppings.Add(mapperTopping.Map(t, context, update)));
            dbPizza.DBPlacedToppings.Clear();

            foreach (var group in mappedToppings.GroupBy(topping => topping.TOPPING))
            {
                var firstTopping = group.Last();

                if (firstTopping is null)
                {
                    throw new ArgumentException("Something went wrong!");
                }

                DBPlacedTopping placedTopping = context.DBPlacedToppings
                    .Include(placedTopping => placedTopping.Pizza).Include(placedTopping => placedTopping.Topping)
                    .FirstOrDefault(placedTopping => placedTopping.Pizza.ID == dbPizza.ID && 
                    placedTopping.Topping.ID == firstTopping.ID) ?? new DBPlacedTopping();

                if (placedTopping.ID != 0 && !update)
                {
                    continue;
                }

                placedTopping.Pizza = dbPizza;
                placedTopping.Topping = firstTopping;
                dbPizza.DBPlacedToppings.Add(placedTopping);
            }

            dbPizza.Price = model.Price;
            if (dbPizza.ID == 0)
            {
                context.DBPizzas.Add(dbPizza);
            }
            return dbPizza;
        }
    }
}