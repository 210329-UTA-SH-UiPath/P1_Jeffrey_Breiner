using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
  public class MapperTopping : IMapper<Topping, DBTopping>
  {
    /// <summary>
    /// Map DBTopping => Topping
    /// Uses enum to determine which topping class to return.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Topping Map(DBTopping entity)
    {
      Topping topping = null;

      switch (entity.TOPPING)
      {
        case Entities.EntityModels.TOPPINGS.BACON:
          topping = new Bacon();
          break;
        case Entities.EntityModels.TOPPINGS.CHICKEN:
          topping = new Chicken();
          break;
        case Entities.EntityModels.TOPPINGS.EXTRACHEESE:
          topping = new ExtraCheese();
          break;
        case Entities.EntityModels.TOPPINGS.GREENPEPPER:
          topping = new GreenPepper();
          break;
        case Entities.EntityModels.TOPPINGS.HAM:
          topping = new Ham();
          break;
        case Entities.EntityModels.TOPPINGS.NOCHEESE:
          topping = new NoCheese();
          break;
        case Entities.EntityModels.TOPPINGS.PINEAPPLE:
          topping = new Pineapple();
          break;
        case Entities.EntityModels.TOPPINGS.REDPEPPER:
          topping = new RedPepper();
          break;
        case Entities.EntityModels.TOPPINGS.SAUSAGE:
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
    public DBTopping Map(Topping model, PizzaDbContext context)
    {
      DBTopping dBTopping = new DBTopping();
      Entities.EntityModels.TOPPINGS TOPPING;

      switch (model)
      {
        case Bacon:
          TOPPING = Entities.EntityModels.TOPPINGS.BACON;
          break;
        case Chicken:
          TOPPING = Entities.EntityModels.TOPPINGS.CHICKEN;
          break;
        case ExtraCheese:
          TOPPING = Entities.EntityModels.TOPPINGS.EXTRACHEESE;
          break;
        case GreenPepper:
          TOPPING = Entities.EntityModels.TOPPINGS.GREENPEPPER;
          break;
        case Ham:
          TOPPING = Entities.EntityModels.TOPPINGS.HAM;
          break;
        case NoCheese:
          TOPPING = Entities.EntityModels.TOPPINGS.NOCHEESE;
          break;
        case Pineapple:
          TOPPING = Entities.EntityModels.TOPPINGS.PINEAPPLE;
          break;
        case RedPepper:
          TOPPING = Entities.EntityModels.TOPPINGS.REDPEPPER;
          break;
        case Sausage:
          TOPPING = Entities.EntityModels.TOPPINGS.SAUSAGE;
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