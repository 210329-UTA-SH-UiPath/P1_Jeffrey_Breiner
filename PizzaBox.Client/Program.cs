using System;
using System.Text;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Client.Singletons;
using PizzaBox.Domain.Abstracts;
using PizzaBox.Domain.Singletons;
using PizzaBox.Domain.Models.Pizzas;
using PizzaBox.Domain.Models.Toppings;
using PizzaBox.Domain.Models.Components;
using PizzaBox.Storing.Repositories;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Client
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {
        public static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        public static readonly PizzaSingleton _pizzaSingleton = PizzaSingleton.Instance;
        public static readonly CrustSingleton _crustSingleton = CrustSingleton.Instance;
        public static readonly SizeSingleton _sizeSingleton = SizeSingleton.Instance;
        public static readonly ToppingSingleton _toppingSingleton = ToppingSingleton.Instance;
        public static readonly PizzaDbContext _context = DbContextSingleton.Instance.Context;

        static void SeedData()
        {
            /*RepositoryOrder repositoryOrder = new RepositoryOrder(DbContextSingleton.Instance.Context);
            Order order = new Order();
            order.Customer.Name = "jeff";
            order.Store = new NewYorkStore();
            order.Pizza.Add(new MeatPizza());
            order.Pizza.Add(new HawaiianPizza());

            repositoryOrder.Add(order);*/


            using (var tempContext = new PizzaDbContext())
            {
                RepositoryStore repositoryStore = new RepositoryStore(DbContextSingleton.Instance.Context);
                repositoryStore.Add(new NewYorkStore());
                repositoryStore.Add(new ChicagoStore());
            }
        }

        /// <summary>
        /// Main. So far, just runs the Run() command.
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            using (var tempContext = new PizzaDbContext())
            {
                //SeedData();
            }
            Run();
        }

        /// <summary>
        /// Prints out a welcome message and the menu. 
        /// Then creates a customer item, allows the user to select a store and pizza.
        /// The order is then saved to a file/db
        /// </summary>
        private static void Run()
        {
            var order = new Order();
            order.Customer = new Customer();

            WelcomeUser();
            Console.WriteLine("\nAre you a...");
            Console.WriteLine("1 - Customer");
            Console.WriteLine("2 - Store Manager");

            int tempInput;
            int options;
            do
            {
                tempInput = SafeUserInput();
            } while (tempInput <= 0 || tempInput > 2);

            if (tempInput == 1)
            {
                Console.WriteLine("\nEnter your name:");
                order.Customer.Name = Console.ReadLine();
                order.Store = SelectStore();
                order.Pizza.Add(SelectPizza());

                do
                {
                    DisplayOrder(order);

                    do
                    {
                        options = 0;
                        Console.WriteLine("Do you want to...");
                        Console.WriteLine($"{++options} - Add another pizza to  your order");
                        Console.WriteLine($"{++options} - Remove a pizza from  your order");
                        Console.WriteLine($"{++options} - Finalize your order");
                        tempInput = SafeUserInput();
                    } while (tempInput <= 0 || tempInput > options);

                    switch (tempInput)
                    {
                        case 1:
                            order.Pizza.Add(SelectPizza());
                            break;
                        case 2:
                            RemovePizza(order);
                            break;
                        case 3:
                            break;
                        default:
                            Console.WriteLine("Something went wrong");
                            break;
                    }
                } while (tempInput != options);


                using (var tempContext = new PizzaDbContext())
                {
                    RepositoryOrder repositoryOrder = new RepositoryOrder(DbContextSingleton.Instance.Context);
                    repositoryOrder.Add(order);
                }
                order.Save();
            }
            else
            {
                var store = SelectStore();

                do
                {
                    options = 0;
                    Console.WriteLine("Do you want to...");
                    Console.WriteLine($"{++options} - View order history");
                    Console.WriteLine($"{++options} - View order history for a specific customer");
                    Console.WriteLine($"{++options} - View the sales report");
                    tempInput = SafeUserInput();
                } while (tempInput <= 0 || tempInput > options);

                using (var tempContext = new PizzaDbContext())
                {
                    RepositoryOrder repositoryOrder = new RepositoryOrder(DbContextSingleton.Instance.Context);
                    List<Order> orders = repositoryOrder.GetList();

                    int index = 0;
                    string customerName = "";
                    decimal revenue = 0;

                    if (tempInput == 2)
                    {
                        customerName = Console.ReadLine();
                    }

                    StringBuilder buffer = new StringBuilder();
                    foreach (var item in orders)
                    {
                        if (item.Store.Name == store.Name)
                        {
                            switch (tempInput)
                            {
                                case 1:
                                    buffer.AppendLine($"\n{++index}:\n{item}");
                                    buffer.AppendLine($"Customer name: {item.Customer.Name}\n");
                                    break;
                                case 2:
                                    if (item.Customer.Name.Equals(customerName))
                                    {
                                        buffer.AppendLine($"{++index}:\n{item}");
                                        buffer.AppendLine($"Customer name: {item.Customer.Name}\n");
                                    }
                                    break;
                                case 3:
                                    buffer.AppendLine($"\n{++index}:\n{item}");
                                    buffer.AppendLine($"Customer name: {item.Customer.Name}\n");
                                    revenue += item.priceTotal;
                                    break;
                                default:
                                    Console.WriteLine("Something went wrong");
                                    break;
                            }
                        }
                    }
                    Console.WriteLine(buffer.ToString());

                    if (tempInput == 3)
                    {
                        Console.WriteLine($"Total revenue: ${revenue}");
                    }
                }
            }

        }

        /// <summary>
        /// Prints out a welcome banner
        /// </summary>
        /// <returns></returns>
        private static void WelcomeUser()
        {
            System.Console.WriteLine("+---------------------+");
            System.Console.WriteLine("| Welcome to PizzaBox |");
            System.Console.WriteLine("+---------------------+");
        }

        /// <summary>
        /// Prints the list of stores
        /// </summary>
        private static void DisplayStoreMenu()
        {
            Console.WriteLine("\nChoose a store:");
            var index = 0;

            foreach (var item in _storeSingleton.Stores)
            {
                Console.WriteLine($"{++index} - {item}");
            }
        }

        /// <summary>
        /// Gets a store from user input. Asks user for input on a loop until valid input is given.
        /// </summary>
        /// <returns></returns>
        private static AStore SelectStore()
        {
            int input;
            DisplayStoreMenu();
            do
            {
                input = SafeUserInput();
            } while (input <= 0 || input > _storeSingleton.Stores.Count);
            return _storeSingleton.Stores[input - 1];
        }

        /// <summary>
        /// Prints the pizza menu
        /// </summary>
        private static void DisplayPizzaMenu()
        {
            Console.WriteLine("\nChoose a pizza:");
            var index = 0;

            foreach (var item in _pizzaSingleton.Pizzas)
            {
                Console.WriteLine($"{++index} - {item.Name}");
            }
        }

        /// <summary>
        /// Gets a pizza from user input. Asks user for input on a loop until valid input is given.
        /// </summary>
        /// <returns></returns>
        private static APizza SelectPizza()
        {
            int input;
            DisplayPizzaMenu();
            do
            {
                input = SafeUserInput();
            } while (input <= 0 || input > _pizzaSingleton.Pizzas.Count);
            var pizza = _pizzaSingleton.Pizzas[input - 1];
            if (pizza is CustomPizza)
            {
                pizza = BuildPizza();
            }

            return pizza;
        }

        /// <summary>
        /// Prints the list of crusts
        /// </summary>
        private static void DisplayCrustMenu()
        {
            Console.WriteLine("\nChoose a crust:");
            var index = 0;

            foreach (var item in _crustSingleton.Crusts)
            {
                Console.WriteLine($"{++index} - {item.Name}: ${item.Price}");
            }
        }

        /// <summary>
        /// Gets a crust from user input. Asks user for input on a loop until valid input is given.
        /// </summary>
        /// <returns></returns>
        private static ACrust SelectCrust()
        {
            int input;
            DisplayCrustMenu();
            do
            {
                input = SafeUserInput();
            } while (input <= 0 || input > _crustSingleton.Crusts.Count);
            var crust = _crustSingleton.Crusts[input - 1];

            return crust;
        }

        /// <summary>
        /// Prints the list of sizes
        /// </summary>
        private static void DisplaySizeMenu()
        {
            Console.WriteLine("\nChoose a size:");
            var index = 0;

            foreach (var item in _sizeSingleton.Sizes)
            {
                Console.WriteLine($"{++index} - {item.Name}: ${item.Price}");
            }
        }

        /// <summary>
        /// Gets a size from user input. Asks user for input on a loop until valid input is given.
        /// </summary>
        /// <returns></returns>
        private static ASize SelectSize()
        {
            int input;
            DisplaySizeMenu();
            do
            {
                input = SafeUserInput();
            } while (input <= 0 || input > _sizeSingleton.Sizes.Count);
            var size = _sizeSingleton.Sizes[input - 1];

            return size;
        }

        /// <summary>
        /// Prints the list of toppings
        /// </summary>
        private static void DisplayToppingsMenu()
        {
            Console.WriteLine("Choose a topping (Max 5):");
            var index = 0;

            foreach (var item in _toppingSingleton.Toppings)
            {
                Console.WriteLine($"{++index} - {item.Name}: ${item.Price}");
            }
        }

        /// <summary>
        /// Gets a topping from user input. Asks user for input on a loop until valid input is given.
        /// </summary>
        /// <returns></returns>
        private static ATopping SelectTopping()
        {
            int input;
            DisplayToppingsMenu();
            do
            {
                input = SafeUserInput();
            } while (input <= 0 || input > _toppingSingleton.Toppings.Count);
            var toppings = _toppingSingleton.Toppings[input - 1];

            return toppings;
        }

        /// <summary>
        /// Builds a custom pizza using user input
        /// </summary>
        private static CustomPizza BuildPizza()
        {
            ACrust crust = SelectCrust();
            ASize size = SelectSize();
            List<ATopping> toppings = new List<ATopping>();

            ATopping topping;
            do
            {
                Console.WriteLine("\nCurrent pizza:");
                Console.WriteLine(new CustomPizza(crust, size, toppings));
                topping = SelectTopping();
                if (!(topping is NoChoice))
                {
                    toppings.Add(topping);
                }
            } while (toppings.Count < 5 && !(topping is NoChoice));
            return new CustomPizza(crust, size, toppings);
        }

        /// <summary>
        /// Displays the order the user chose
        /// </summary>
        private static void DisplayOrder(Order order)
        {
            Console.WriteLine($"\nYour order is:\n{order}");
        }

        /// <summary>
        /// Allows the user to remove a pizza from their order
        /// </summary>
        private static void RemovePizza(Order order)
        {
            DisplayOrder(order);
            Console.WriteLine($"Choose which pizza you wish to remove: (Press 0 to go back)");

            int input;
            do
            {
                input = SafeUserInput();
            } while (input < 0 || input > order.Pizza.Count);

            if (input != 0)
            {
                order.Pizza.RemoveAt(input - 1);
            }
        }

        /// <summary>
        /// Gets input from the user and returns either that input or,
        /// if not an int, returns -1 and instructs the user to enter an integer.
        /// </summary>
        /// <returns></returns>
        private static int SafeUserInput()
        {
            int input;
            try
            {
                input = int.Parse(Console.ReadLine());
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid input. Please enter a whole number.");
                input = 0;
            }
            return input;
        }
    }
}
