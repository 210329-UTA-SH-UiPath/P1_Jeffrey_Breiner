using System;
using System.Collections.Generic;
using System.Linq;
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

            return pizza;
        }

        /// <summary>
        /// Map DBPizza => DBPizza
        /// Sets enum bassed off what pizza class was passed into it.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBPizza Map(APizza model, PizzaDbContext context)
        {
            DBPizza dBPizza = new DBPizza();
            PIZZAS PIZZA;

            switch (model)
            {
                case CustomPizza:
                    PIZZA = PIZZAS.CUSTOM;
                    break;
                case HawaiianPizza:
                    PIZZA = PIZZAS.HAWAIIAN;
                    break;
                case MeatPizza:
                    PIZZA = PIZZAS.MEAT;
                    break;
                case VeganPizza:
                    PIZZA = PIZZAS.VEGAN;
                    break;
                default:
                    throw new ArgumentException("Size not recognized. Size could not be mapped properly");
            }

            dBPizza.PIZZA = PIZZA;
            dBPizza.DBCrust = mapperCrust.Map(model.Crust, context);
            dBPizza.DBSize = mapperSize.Map(model.Size, context);
            List<DBTopping> toppings = new List<DBTopping>();
            model.Toppings.ForEach(Topping => toppings.Add(mapperTopping.Map(Topping, context)));

            foreach (var group in toppings.GroupBy(topping => topping.TOPPING))
            {
                var firstTopping = group.First();

                if (firstTopping is null)
                {
                    throw new ArgumentException("Something went horribly wrong!");
                }

                DBPlacedTopping placedTopping = new DBPlacedTopping();
                placedTopping.Pizza = dBPizza;
                placedTopping.Topping = firstTopping;
                dBPizza.DBPlacedToppings.Add(placedTopping);
            }

            dBPizza.Price = model.CalculatePrice();
            return dBPizza;
        }
    }
}