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
{/*
    public class FEPizzaController : Controller
    {
        [HttpGet]
        public IActionResult SalesReport(int daysAgo)
        {
            var APIStores = new StoreApi(new Configuration { BasePath = "https://localhost:44368/" });
            var stores = APIStores.ApiStoreGet();
            var APIOrders = new OrderApi(new Configuration { BasePath = "https://localhost:44368/" });
            var orders = APIOrders.ApiOrderGet();
            var APIPizzas = new PizzaApi(new Configuration { BasePath = "https://localhost:44368/" });
            var pizzas = APIPizzas.ApiPizzaGet();
            List<SalesReport> summary = pizzas.Join(orders, pizza => pizza.OrderID, order => order.Id, (pizza, order) => new { Pizza = pizza, Order = order })
                .Where(row => (DateTime.Now - (DateTime)row.Order.TimeStamp).TotalDays <= daysAgo)
                .GroupBy(sales1 => sales1.Pizza).Select(sales2 => new SalesReport
                {
                    Item = Enum.GetName<PIZZAS>(sales2.First().Pizza.Pizza),
                    Quantity = sales2.Count(),
                    Revenue = sales2.Sum(sales => (double)sales.Pizza.Price)
                }).ToList();


            return View(summary);
        }
    }*/
}
