using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Controllers;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IO.Swagger.Client;
using IO.Swagger.Api;
using IO.Swagger.Model;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FEOrderController : Controller
    {
        public IActionResult ManagerSeat()
        {
            //var client = new ApiClient();
            var API = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });
            var orders = API.ApiOrderGet();
            //var orders = FEOrderClient.GetOrders();
            return View(orders);
        }

        public ViewResult GetById(int id)
        {
            var order = FEOrderClient.GetOrderById(id);
            return View(order);
        }

        public IActionResult PizzaMenu(List<APizza> fleshedOutPizza)
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            if (fleshedOutPizza != null)
            {
                if (!IsValidPizzaCount(fleshedOutPizza.Count, sessionOrder.Pizza.Count))
                {
                    ViewBag.ErrorMessage = "You can only order 50 pizzas at a time.";
                    return View("PizzaMenu", sessionOrder);
                }
                if (!IsValidPizzaPrice(Convert.ToDecimal(fleshedOutPizza.Sum(pizza => pizza.Price)), Convert.ToDecimal(sessionOrder.PriceTotal)))
                {
                    ViewBag.ErrorMessage = "The total price of yor order cannot exceed $250.";
                    return View("PizzaMenu", sessionOrder);
                }
                sessionOrder.Pizza.AddRange(fleshedOutPizza);
                Utils.SaveOrder(HttpContext.Session, sessionOrder);
            }

            return View("PizzaMenu", sessionOrder);
        }

        public IActionResult Remove(int Index)
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            sessionOrder.Pizza.RemoveAt(Index);
            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return PizzaMenu(null);
        }

        public bool IsValidPizzaCount(int pizzaCount, int orderCount)
        {
            return orderCount + pizzaCount <= 50;
        }

        public bool IsValidPizzaPrice(decimal pizzaPrice, decimal orderPrice)
        {
            return orderPrice + pizzaPrice <= 250m;
        }

        [HttpGet]
        public IActionResult PlaceOrderWithMeat()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            APizza pizza = new APizza();
            pizza.Pizza = PIZZAS.MEAT;
            ASize size = new ASize();
            size.Size = SIZES.LARGE;
            pizza.Size = size;
            sessionOrder.Pizza.Add(pizza);

            bool result = FEOrderClient.AddOrder(sessionOrder);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AddPizza(PIZZAS pizza, SIZES size, CRUSTS crust, List<TOPPINGS> topping)
        {
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });

            var fleshedOutPizza = API.ApiValuesPIZZASIZECRUSTGet(pizza, size, crust, topping);
            return PizzaMenu(new List<APizza> { fleshedOutPizza });
        }
        /*
        public IActionResult AddMeatPizza()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });

            var pizza = PIZZAS.MEAT;

            var fleshedOutPizza = API.ApiValuesPIZZASIZEGet(pizza, size);
            return PizzaMenu(new List<APizza> { fleshedOutPizza });
        }

        public IActionResult AddHawaiianPizza()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });

            var pizza = PIZZAS.HAWAIIAN;

            var fleshedOutPizza = API.ApiValuesPIZZASIZEGet(pizza, size);
            return PizzaMenu(new List<APizza> { fleshedOutPizza });
        }

        public IActionResult AddHeathenPizza()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });

            var pizza = PIZZAS.VEGAN;

            var fleshedOutPizza = API.ApiValuesPIZZASIZEGet(pizza, size);
            return PizzaMenu(new List<APizza> { fleshedOutPizza });
        }
        */
        public IActionResult AddHeathenPack()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });
            List<APizza> fleshedOutPizza = new List<APizza>();

            for (int i = 0; i < 50; i++)
            {
                var pizza = PIZZAS.VEGAN;
                var size = SIZES.SMALL;

                var apizza = API.ApiValuesPIZZASIZEGet(pizza, size);
                fleshedOutPizza.Add(apizza);
            }

            return PizzaMenu(fleshedOutPizza);
        }

        public IActionResult AddHawaiianFeast()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new ValuesApi(new Configuration { BasePath = "https://localhost:44368/" });
            List<APizza> fleshedOutPizza = new List<APizza>();

            for (int i = 0; i < 16; i++)
            {
                var pizza = PIZZAS.HAWAIIAN;
                var size = SIZES.LARGE;

                var apizza = API.ApiValuesPIZZASIZEGet(pizza, size);
                fleshedOutPizza.Add(apizza);
            }

            return PizzaMenu(fleshedOutPizza);
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });

            API.ApiOrderPost(sessionOrder);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult GetOrdersByCustomer(string Name)
        {
            if (Name is null)
            {
                return BadRequest("Customer field was empty or null");
            }
            var APICustomer = new CustomerApi(new Configuration { BasePath = "https://localhost:44368/" });
            var customers = APICustomer.ApiCustomerGet();
            var foundCustomer = customers.FirstOrDefault(cust => cust.Name.Equals(Name));

            if (foundCustomer is not null)
            {
                var APIOrder = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });
                var orders = APIOrder.ApiOrderGet();
                List<Order> customerOrders = orders.Where(
                    order => order.Customer.Id.Equals(foundCustomer.Id)).ToList();
                return View(customerOrders);
            }

            ViewBag.ErrorMessage = "This user has no previous orders.";
            return View("ViewCustomerOrders");
        }
    }
}
