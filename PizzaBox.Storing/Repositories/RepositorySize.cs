using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
  public class RepositorySize : IRepository<Size>
  {
    public readonly PizzaDbContext context;
    public readonly MapperSize mapperSize = new MapperSize();

    public RepositorySize(PizzaDbContext context)
    {
      this.context = context;
    }

    public void Add(Size genericType)
    {
      context.DBSizes.Add(mapperSize.Map(genericType, context));
      context.SaveChanges();
    }

    public List<Size> GetList()
    {
      List<Size> sizes = new List<Size>();
      context.DBSizes.AsEnumerable().GroupBy(size => size.SIZE).Select(size => size.First()).ToList().ForEach(size => sizes.Add(mapperSize.Map(size)));
      return sizes;
    }

    public void Remove(Size genericType)
    {
      DBSize dBSize = mapperSize.Map(genericType, context);
      DBSize size = context.DBSizes.ToList().Find(size => size.SIZE == dBSize.SIZE);

      if (size is not null)
      {
        context.Remove(size);
        context.SaveChanges();
      }
    }

    public void update(Size existingType, Size updatedType)
    {
      DBSize dBSize = mapperSize.Map(existingType, context);
      DBSize size = context.DBSizes.ToList().Find(size => size.SIZE == dBSize.SIZE);

      if (size is not null)
      {
        DBSize EntityMapped = mapperSize.Map(updatedType, context);
        size.SIZE = EntityMapped.SIZE;
        size.Price = EntityMapped.Price;
        context.SaveChanges();
      }
    }
  }
}