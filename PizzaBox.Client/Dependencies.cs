/*using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Client
{
  public static class Dependencies
  {
    public static IRepository CreateRepository()
    {
      var optionsBuilder = new DbContextOptionsBuilder<PizzaDbContext>();
      optionsBuilder.UseSqlServer("Server=tcp:project0dbserver.database.windows.net,1433;Initial Catalog=Project0DB;User ID=jeffreybreiner;Password=Wouldyouliketomakeawallet1;");
      var dbContext = new PizzaDbContext(optionsBuilder.Options);
      return new Repository(dbContext);
    }
  }
}*/