using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Crusts;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
  public class MapperCrust : IMapper<Crust, DBCrust>
  {
    /// <summary>
    /// Map DBCrust => Crust
    /// Uses enum to determine which crust class to return.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Crust Map(DBCrust entity)
    {
      Crust crust = null;

      switch (entity.CRUST)
      {
        case Entities.EntityModels.CRUSTS.DEEPDISH:
          crust = new DeepDishCrust();
          break;
        case Entities.EntityModels.CRUSTS.STANDARD:
          crust = new StandardCrust();
          break;
        case Entities.EntityModels.CRUSTS.STUFFED:
          crust = new StuffedCrust();
          break;
        case Entities.EntityModels.CRUSTS.THIN:
          crust = new ThinCrust();
          break;
        default:
          throw new ArgumentException("Crust type not recognized. Crust could not be mapped properly");
      }

      crust.ID = entity.ID;
      return crust;
    }

    /// <summary>
    /// Map Crust => DBCrust
    /// Sets enum bassed off what crust class was passed into it.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public DBCrust Map(Crust model, PizzaDbContext context)
    {
      DBCrust dBCrust = new DBCrust();
      Entities.EntityModels.CRUSTS CRUST;

      switch (model)
      {
        case DeepDishCrust:
          CRUST = Entities.EntityModels.CRUSTS.DEEPDISH;
          break;
        case StandardCrust:
          CRUST = Entities.EntityModels.CRUSTS.STANDARD;
          break;
        case StuffedCrust:
          CRUST = Entities.EntityModels.CRUSTS.STUFFED;
          break;
        case ThinCrust:
          CRUST = Entities.EntityModels.CRUSTS.THIN;
          break;
        default:
          throw new ArgumentException("Crust type not recognized. Crust could not be mapped properly");
      }

      var dbCrust = context.DBCrusts.FirstOrDefault(crust => crust.CRUST == CRUST);
      if (dbCrust is not null)
      {
        return dbCrust;
      }

      dBCrust.CRUST = CRUST;
      dBCrust.Price = model.Price;
      return dBCrust;
    }
  }
}