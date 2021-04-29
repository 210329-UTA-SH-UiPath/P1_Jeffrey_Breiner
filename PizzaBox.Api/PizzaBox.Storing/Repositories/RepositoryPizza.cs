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

        public APizza GetById(int id)
        {
            var dbPizza = context.DBPizzas.FirstOrDefault(pizza => pizza.ID == id);

            if (dbPizza is null)
            {
                return null;
            }

            return mapperPizza.Map(dbPizza);
        }

        public void Remove(int id)
        {
            DBPizza pizza = context.DBPizzas.FirstOrDefault(pizza => pizza.ID == id);

            if (pizza is not null)
            {
                context.Remove(pizza);
                context.SaveChanges();
            }
        }

        public APizza Update(APizza updatedType)
        {
            DBPizza dBPizza = mapperPizza.Map(updatedType, context);
            context.SaveChanges();
            return mapperPizza.Map(dBPizza);
        }
    }
}