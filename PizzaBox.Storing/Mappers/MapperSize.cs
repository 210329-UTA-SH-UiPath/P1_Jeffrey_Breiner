using System;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Domain.Models.Sizes;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;

namespace PizzaBox.Storing.Mappers
{
  public class MapperSize : IMapper<Size, DBSize>
  {
    /// <summary>
    /// Map DBSize => Size
    /// Uses enum to determine which size class to return.
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public Size Map(DBSize entity)
    {
      Size size = null;

      switch (entity.SIZE)
      {
        case Entities.EntityModels.SIZES.SMALL:
          size = new SmallSize();
          break;
        case Entities.EntityModels.SIZES.MEDIUM:
          size = new MediumSize();
          break;
        case Entities.EntityModels.SIZES.LARGE:
          size = new LargeSize();
          break;
        default:
          throw new ArgumentException("Size not recognized. Size could not be mapped properly");
      }

      size.ID = entity.ID;
      return size;
    }

    /// <summary>
    /// Map Size => DBSize
    /// Sets enum bassed off what size class was passed into it.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public DBSize Map(Size model, PizzaDbContext context)
    {
      DBSize dBSize = new DBSize();
      Entities.EntityModels.SIZES SIZE;

      switch (model)
      {
        case SmallSize:
          SIZE = Entities.EntityModels.SIZES.SMALL;
          break;
        case MediumSize:
          SIZE = Entities.EntityModels.SIZES.MEDIUM;
          break;
        case LargeSize:
          SIZE = Entities.EntityModels.SIZES.LARGE;
          break;
        default:
          throw new ArgumentException("Size type not recognized. Size could not be mapped properly");
      }

      var dbSize = context.DBSizes.FirstOrDefault(size => size.SIZE == SIZE);
      if (dbSize is not null)
      {
        return dbSize;
      }

      dBSize.SIZE = SIZE;
      dBSize.Price = model.Price;
      return dBSize;
    }
  }
}