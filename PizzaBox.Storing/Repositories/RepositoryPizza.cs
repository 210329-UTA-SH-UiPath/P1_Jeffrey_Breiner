using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Repositories
{
  public class RepositoryPizza : IRepository<APizza>
  {
    private readonly MapperPizza mapperPizza = new MapperPizza();
    private readonly PizzaDbContext context;
    public RepositoryPizza(PizzaDbContext context)
    {
      this.context = context;
    }
    public void Add(APizza genericType)
    {
      context.DBPizzas.Add(mapperPizza.Map(genericType, context));
      context.SaveChanges();
    }

    public List<APizza> GetList()
    {
      List<APizza> pizzas = new List<APizza>();
      context.DBPizzas.Include(pizza => pizza.DBCrust).Include(pizza => pizza.DBSize).Include(pizza => pizza.DBPlacedToppings)
        .AsEnumerable().GroupBy(pizza => pizza.PIZZA).Select(pizza => pizza.First()).ToList().ForEach(pizza => pizzas.Add(mapperPizza.Map(pizza)));
      return pizzas;
    }

    public void Remove(APizza genericType)
    {
      DBPizza dbPizza = mapperPizza.Map(genericType, context);
      DBPizza pizza = context.DBPizzas.ToList().Find(pizza => pizza.GetHashCode() == dbPizza.GetHashCode());

      if (pizza is not null)
      {
        context.Remove(pizza);
        context.SaveChanges();
      }
    }

    public void update(APizza existingType, APizza updatedType)
    {
      DBPizza dbPizza = mapperPizza.Map(existingType, context);
      DBPizza pizza = context.DBPizzas.ToList().Find(pizza => pizza.GetHashCode() == dbPizza.GetHashCode());

      if (pizza is not null)
      {
        DBPizza pizzaUpdated = mapperPizza.Map(existingType, context);
        pizza.DBCrust = pizzaUpdated.DBCrust;
        pizza.DBSize = pizzaUpdated.DBSize;
        pizza.DBPlacedToppings = pizzaUpdated.DBPlacedToppings;
        pizza.PIZZA = pizzaUpdated.PIZZA;
        pizza.Price = pizzaUpdated.Price;
        context.SaveChanges();
      }
    }
  }

}