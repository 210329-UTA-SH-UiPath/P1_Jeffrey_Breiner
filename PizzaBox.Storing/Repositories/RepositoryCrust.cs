using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
  public class RepositoryCrust : IRepository<Crust>
  {
    public readonly PizzaDbContext context;
    public readonly MapperCrust mapperCrust = new MapperCrust();

    public RepositoryCrust(PizzaDbContext context)
    {
      this.context = context;
    }

    public void Add(Crust genericType)
    {
      context.DBCrusts.Add(mapperCrust.Map(genericType, context));
      context.SaveChanges();
    }

    /// <summary>
    /// This is coding wizardry.
    /// Google says it works.
    /// It does work.
    /// I didn't question it.
    /// It is a workaround for storing enums as uniques in the db.
    /// </summary>
    /// <returns></returns>
    public List<Crust> GetList()
    {
      List<Crust> crusts = new List<Crust>();
      context.DBCrusts.AsEnumerable().GroupBy(crust => crust.CRUST).Select(crust => crust.First()).ToList().ForEach(crust => crusts.Add(mapperCrust.Map(crust)));
      return crusts;
    }

    public void Remove(Crust genericType)
    {
      DBCrust dBCrust = mapperCrust.Map(genericType, context);
      DBCrust crust = context.DBCrusts.ToList().Find(crust => crust.CRUST == dBCrust.CRUST);

      if (crust is not null)
      {
        context.Remove(crust);
        context.SaveChanges();
      }
    }

    public void update(Crust existingType, Crust updatedType)
    {
      DBCrust dBCrust = mapperCrust.Map(existingType, context);
      DBCrust crust = context.DBCrusts.ToList().Find(crust => crust.CRUST == dBCrust.CRUST);

      if (crust is not null)
      {
        DBCrust EntityMapped = mapperCrust.Map(updatedType, context);
        crust.CRUST = EntityMapped.CRUST;
        crust.Price = EntityMapped.Price;
        context.SaveChanges();
      }
    }
  }
}