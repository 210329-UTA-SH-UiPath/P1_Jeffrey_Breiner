﻿using Microsoft.EntityFrameworkCore;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities.EntityModels;
using PizzaBox.Storing.Mappers;

namespace PizzaBox.Storing.Entities
{
    public partial class PizzaDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:project0dbserver.database.windows.net,1433;Initial Catalog=Project0DB;User ID=jeffreybreiner;Password=Wouldyouliketomakeawallet1;");
        }
        public DbSet<DBStore> DBStores { get; set; }
        public DbSet<DBCustomer> DBCustomers { get; set; }
        public DbSet<DBOrder> DBOrders { get; set; }
        public DbSet<DBPizza> DBPizzas { get; set; }
        public DbSet<DBCrust> DBCrusts { get; set; }
        public DbSet<DBSize> DBSizes { get; set; }
        public DbSet<DBTopping> DBToppings { get; set; }
        public DbSet<DBPlacedTopping> DBPlacedToppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DBTopping>().HasIndex(topping => topping.TOPPING).IsUnique();
            modelBuilder.Entity<DBCrust>().HasIndex(crust => crust.CRUST).IsUnique();
            modelBuilder.Entity<DBSize>().HasIndex(size => size.SIZE).IsUnique();
            modelBuilder.Entity<DBStore>().HasIndex(store => store.Name).IsUnique();
            modelBuilder.Entity<DBCustomer>().HasIndex(customer => customer.Name).IsUnique();

            modelBuilder.Entity<DBTopping>().HasMany(topping => topping.DBPlacedToppings).WithOne(placedTopping => placedTopping.Topping);
            modelBuilder.Entity<DBPizza>().HasMany(pizza => pizza.DBPlacedToppings).WithOne(placedTopping => placedTopping.Pizza);

            modelBuilder.Entity<DBOrder>().HasOne(order => order.DBCustomer);
            modelBuilder.Entity<DBOrder>().HasOne(order => order.DBStore);

            //MapperStore mapperStore = new MapperStore();
            //modelBuilder.Entity<DBStore>().HasData(mapperStore.Map(new NewYorkStore(), this));
            //modelBuilder.Entity<DBStore>().HasData(mapperStore.Map(new ChicagoStore(), this));

            base.OnModelCreating(modelBuilder);
        }
    }
}
