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

            ViewBag.Stores = new SelectList(FEStoreClient.GetStores(), "ID", "Name");
            return View(new FEStore());
        }

        [HttpPost]
        public IActionResult GetSelectedStore(FEStore Store)
        {
            var dbStore = FEStoreClient.GetStores().FirstOrDefault(store => store.ID == Store.ID);

            if (dbStore is null)
            {
                return BadRequest("You selected a null store.");
            }

            var sessionOrder = Utils.GetCurrentOrder(HttpContext.Session);
            sessionOrder.Store.Name = dbStore.Name;
            sessionOrder.Store.STORE = dbStore.STORE;
            sessionOrder.Store.ID = dbStore.ID;

            Utils.SaveOrder(HttpContext.Session, sessionOrder);
            return RedirectToAction("PizzaMenu", "FEOrder");
        }
    }
}
