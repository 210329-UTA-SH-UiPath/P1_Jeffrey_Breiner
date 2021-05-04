using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PizzaBox.Client.Controllers;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FEStoreController : Controller
    {
        public IActionResult SelectStore()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var API = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });
            var orders = API.ApiOrderGet();
            var API2 = new StoreApi(new Configuration { BasePath = "https://localhost:44368/" });
            var stores = API2.ApiStoreGet();

            List<Order> previousOrders = orders.Where(
                order => order.Customer.Name.Equals(sessionOrder.Customer.Name)).OrderByDescending(order => order.TimeStamp).ToList();
            List<AStore> storesToDisplay = new List<AStore>();
#if !DEBUG
            if (previousOrders.Any() && timeSinceOrder(previousOrders.First()).TotalHours < 2)
            {
                return BadRequest("At least 2 hours must pass since your last order before you can place another.");
            }
            foreach (var store in stores)
            {
                var lastOrderFromStore = previousOrders.FirstOrDefault(order => order.Store.Name.Equals(store.Name));

                if (lastOrderFromStore is null || timeSinceOrder(lastOrderFromStore).TotalHours >= 24)
                {
                    storesToDisplay.Add(store);
                }
            }
#else
            storesToDisplay = stores;
#endif

            if (storesToDisplay.Count == 0)
            {
                return BadRequest("There is a 24 hour waiting period for making repeat orders at each store. All stores are currently under this waiting period.");
            }

            ViewBag.Stores = new SelectList(storesToDisplay.ToList(), "Id", "Name");
            return View(new AStore());
        }

        public TimeSpan timeSinceOrder(Order newestOrder)
        {
            if (newestOrder is not null)
            {
                DateTime newestOrderTime = (DateTime)newestOrder.TimeStamp;
                return System.DateTime.Now - newestOrderTime;
            }
            else
            {
                return new TimeSpan(99999999, 0, 0);
            }
        }

        [HttpPost]
        public IActionResult GetSelectedStore(AStore selectedStore)
        {
            var API = new StoreApi(new Configuration { BasePath = "https://localhost:44368/" });
            var stores = API.ApiStoreGet();
            var foundStore = stores.FirstOrDefault(store => store.Id == selectedStore.Id); //grab identicle store from db

            if (foundStore is null)
            {
                return BadRequest("You selected a null store.");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);      //grabbing sessionn info and placing store info into it
            sessionOrder.Store.Id = (int)foundStore.Id;
            sessionOrder.Store.Name = foundStore.Name;
            sessionOrder.Store.Store = foundStore.Store;

            Utils.SaveOrder(HttpContext.Session, sessionOrder);                 //save session
            return RedirectToAction("PizzaMenu", "FEOrder");
        }

        [HttpGet]
        public IActionResult SalesReport(int daysAgo)
        {
            var APIStores = new StoreApi(new Configuration { BasePath = "https://localhost:44368/" });
            var stores = APIStores.ApiStoreGet();
            var APIOrders = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });
            var orders = APIOrders.ApiOrderGet();

            List<SalesReport> summary = orders.Where(sales => (DateTime.Now - (DateTime)sales.TimeStamp).TotalDays <= daysAgo)
                .GroupBy(sales1 => sales1.Store).Select(sales2 => new SalesReport
                {
                    Item = sales2.First().Store.Name,
                    Quantity = sales2.Count(),
                    Revenue = sales2.Sum(sales => (double)sales.PriceTotal),
                    Pizzas = sales2.SelectMany(group => group.Pizza).GroupBy(pizza => pizza.Pizza).Select(pizzaGroup => new SalesReport
                    {
                        Item = pizzaGroup.First().Name,
                        Quantity = pizzaGroup.Count(),
                        Revenue = pizzaGroup.Sum(sales => (double)sales.Price),
                    }).OrderBy(report=>report.Item)
                }).ToList();

            return View(summary);
        }
    }
}
