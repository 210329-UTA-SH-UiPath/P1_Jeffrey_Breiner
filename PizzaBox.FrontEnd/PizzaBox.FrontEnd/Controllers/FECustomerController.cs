using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;
using Microsoft.AspNetCore.Mvc;
using PizzaBox.Client.Controllers;
using PizzaBox.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FECustomerController : Controller
    {
        public IActionResult EnterCustomerName()
        {
            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            HttpContext.Session.Clear();
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult CheckCustomerName(string Name)
        {
            if (Name is null)
            {
                return BadRequest("Customer field was empty or null");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);                          //get current session
            var API = new CustomerApi(new Configuration { BasePath = "https://localhost:44368/" });
            var customers = API.ApiCustomerGet();                                                    //grabs list of customers from DB
            var foundCustomer = customers.FirstOrDefault(cust => cust.Name.Equals(Name));  //checks if the customer name entered already exists in the DB

            if (foundCustomer is not null)                                                          //if the user exists in the DB, apply the ID found in the DB
            {
                sessionOrder.Customer = foundCustomer;
            }
            else
            {
                sessionOrder.Customer = new Customer(Name);
            }

            //sessionOrder.Customer.Name = Name;                                             //saves customer in the session data
            Utils.SaveOrder(HttpContext.Session, sessionOrder);                                     //saves the session data for use on another page

            return RedirectToAction("SelectStore", "FEStore");
        }
        public IActionResult ViewCustomerOrders()
        {
            return View(new Customer());
        }
    }
}
