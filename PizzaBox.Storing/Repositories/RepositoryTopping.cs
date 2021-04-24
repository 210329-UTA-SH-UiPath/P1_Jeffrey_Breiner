using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
  public class RepositoryTopping : IRepository<Topping>
  {
    public readonly PizzaDbContext context;
    public readonly MapperTopping mapperTopping = new MapperTopping();

    public RepositoryTopping(PizzaDbContext context)
    {
      this.context = context;
    }

    public void Add(Topping genericType)
    {
      context.DBToppings.Add(mapperTopping.Map(genericType, context));
      context.SaveChanges();
    }

    public List<Topping> GetList()
    {
      List<Topping> toppings = new List<Topping>();
      context.DBToppings.AsEnumerable().GroupBy(topping => topping.TOPPING).Select(topping => topping.First()).ToList().ForEach(topping => toppings.Add(mapperTopping.Map(topping)));
      return toppings;
    }

    public void Remove(Topping genericType)
    {
      DBTopping dBTopping = mapperTopping.Map(genericType, context);
      DBTopping topping = context.DBToppings.ToList().Find(topping => topping.TOPPING == dBTopping.TOPPING);

      if (topping is not null)
      {
        context.Remove(topping);
        context.SaveChanges();
      }
    }

    public void update(Topping existingType, Topping updatedType)
    {
      DBTopping dBTopping = mapperTopping.Map(existingType, context);
      DBTopping topping = context.DBToppings.ToList().Find(topping => topping.TOPPING == dBTopping.TOPPING);

      if (topping is not null)
      {
        DBTopping EntityMapped = mapperTopping.Map(updatedType, context);
        topping.TOPPING = EntityMapped.TOPPING;
        topping.Price = EntityMapped.Price;
        context.SaveChanges();
      }
    }
  }
}