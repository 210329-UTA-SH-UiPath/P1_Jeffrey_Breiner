using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
    public class MapperTopping : IMapper<ATopping, DBTopping>
    {
        /// <summary>
        /// Map DBTopping => Topping
        /// Uses enum to determine which topping class to return.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ATopping Map(DBTopping entity)
        {
            ATopping topping = null;

            switch (entity.TOPPING)
            {
                case TOPPINGS.BACON:
                    topping = new Bacon();
                    break;
                case TOPPINGS.CHICKEN:
                    topping = new Chicken();
                    break;
                case TOPPINGS.EXTRACHEESE:
                    topping = new ExtraCheese();
                    break;
                case TOPPINGS.GREENPEPPER:
                    topping = new GreenPepper();
                    break;
                case TOPPINGS.HAM:
                    topping = new Ham();
                    break;
                case TOPPINGS.NOCHEESE:
                    topping = new NoCheese();
                    break;
                case TOPPINGS.PINEAPPLE:
                    topping = new Pineapple();
                    break;
                case TOPPINGS.REDPEPPER:
                    topping = new RedPepper();
                    break;
                case TOPPINGS.SAUSAGE:
                    topping = new Sausage();
                    break;
                default:
                    throw new ArgumentException("Topping not recognized. Topping could not be mapped properly");
            }

            topping.ID = entity.ID;
            return topping;
        }

        /// <summary>
        /// Map Topping => DBTopping
        /// Sets enum bassed off what topping class was passed into it.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DBTopping Map(ATopping model, PizzaDbContext context)
        {
            DBTopping dBTopping = new DBTopping();
            TOPPINGS TOPPING;

            switch (model)
            {
                case Bacon:
                    TOPPING = TOPPINGS.BACON;
                    break;
                case Chicken:
                    TOPPING = TOPPINGS.CHICKEN;
                    break;
                case ExtraCheese:
                    TOPPING = TOPPINGS.EXTRACHEESE;
                    break;
                case GreenPepper:
                    TOPPING = TOPPINGS.GREENPEPPER;
                    break;
                case Ham:
                    TOPPING = TOPPINGS.HAM;
                    break;
                case NoCheese:
                    TOPPING = TOPPINGS.NOCHEESE;
                    break;
                case Pineapple:
                    TOPPING = TOPPINGS.PINEAPPLE;
                    break;
                case RedPepper:
                    TOPPING = TOPPINGS.REDPEPPER;
                    break;
                case Sausage:
                    TOPPING = TOPPINGS.SAUSAGE;
                    break;
                default:
                    throw new ArgumentException("Topping type not recognized. Topping could not be mapped properly");
            }

            var dbTopping = context.DBToppings.FirstOrDefault(topping => topping.TOPPING == TOPPING);
            if (dbTopping is not null)
            {
                return dbTopping;
            }

            dBTopping.TOPPING = TOPPING;
            dBTopping.Price = model.Price;
            return dBTopping;
        }
    }
}