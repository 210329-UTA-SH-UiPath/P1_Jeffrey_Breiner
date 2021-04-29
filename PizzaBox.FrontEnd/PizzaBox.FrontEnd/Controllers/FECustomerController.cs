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
            return View(new FECustomer());
        }
        [HttpPost]
        public IActionResult CheckCustomerName(FECustomer customer)
        {
            if (customer is null)
            {
                return BadRequest("Customer field was empty or null");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            var customers = FECustomerClient.GetCustomers();
            var foundCustomer = customers.FirstOrDefault(cust => cust.Name.Equals(customer.Name));

            if (foundCustomer is not null)
            {
                sessionOrder.Customer.ID = foundCustomer.ID;
            }

            sessionOrder.Customer.Name = customer.Name;
            Utils.SaveOrder(HttpContext.Session, sessionOrder);

            return RedirectToAction("SelectStore", "FEStore");
        }
    }
}
