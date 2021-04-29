using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Controllers;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FEOrderController : Controller
    {
        public IActionResult ManagerSeat()
        {
            var orders = FEOrderClient.GetOrders();
            return View(orders);
        }

        public ViewResult GetById(int id)
        {
            var order = FEOrderClient.GetOrderById(id);
            return View(order);
        }

        public IActionResult PizzaMenu()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            return View(sessionOrder);
        }

        [HttpGet]
        public IActionResult PlaceOrder()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            bool result = FEOrderClient.AddOrder(sessionOrder);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult PlaceOrderWithMeat()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);

            FECrust crust = new FECrust();
            FESize size = new FESize();
            FETopping topping1 = new FETopping();
            FETopping topping2 = new FETopping();
            FETopping topping3 = new FETopping();

            crust.Name = "Stuffed Crust";
            crust.Price = 2m;
            crust.CRUST = CRUSTS.STUFFED;

            size.Name = "Medium";
            size.Price = 8m;
            size.SIZE = SIZES.MEDIUM;

            topping1.Name = "Bacon";
            topping1.Price = 0.5m;
            topping1.TOPPING = TOPPINGS.BACON;

            topping2.Name = "Bacon";
            topping2.Price = 0.5m;
            topping2.TOPPING = TOPPINGS.BACON;

            topping3.Name = "Bacon";
            topping3.Price = 0.5m;
            topping3.TOPPING = TOPPINGS.BACON;

            FEPizza pizza = new FEPizza();
            pizza.Crust = crust;
            pizza.Size = size;
            pizza.Toppings.Add(topping1);
            pizza.Toppings.Add(topping2);
            pizza.Toppings.Add(topping3);

            sessionOrder.Pizza.Add(pizza);

            bool result = FEOrderClient.AddOrder(sessionOrder);

            return RedirectToAction("Index", "Home");
        }
    }
}
