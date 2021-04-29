using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBox.Client.Controllers;
using PizzaBox.Client.Models;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FEPizzaController : Controller
    {
        public IActionResult SelectPizzaType()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var PIZZA = FEPizzaClient.GetPizzaTypes();

            ViewBag.PIZZA = new SelectList(PIZZA, "PIZZA", "Name");
            sessionOrder.Pizza.Add(new FEPizza());
            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return View(new FEOrderHolding());
        }

        [HttpPost]
        public IActionResult PizzaTypeSelected(FEOrderHolding orderHolding)
        {
            var dbPizza = FEPizzaClient.GetPizzas().FirstOrDefault(pizza => pizza.PIZZA == orderHolding.PIZZA);

            if (dbPizza is null)
            {
                return BadRequest("The type of pizza that you have selected doesn't exist in the database");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var lastSelectedPizza = sessionOrder.Pizza.Last();

            lastSelectedPizza.Name = dbPizza.Name;
            lastSelectedPizza.PIZZA = dbPizza.PIZZA;
            lastSelectedPizza.Crust = dbPizza.Crust;
            lastSelectedPizza.Size = dbPizza.Size;
            lastSelectedPizza.Toppings = dbPizza.Toppings;

            if (lastSelectedPizza.PIZZA == PIZZAS.CUSTOM)
            {
                lastSelectedPizza.Toppings.Clear();
            }

            Utils.SaveOrder(HttpContext.Session, sessionOrder);
            return RedirectToAction("SelectPizzaSize", "FEPizza");
        }
    }
}
