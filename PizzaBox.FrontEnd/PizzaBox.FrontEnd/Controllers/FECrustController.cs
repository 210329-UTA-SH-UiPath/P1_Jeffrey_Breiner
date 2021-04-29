using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaBox.FrontEnd.Controllers
{
    public class FECrustController : Controller
    {
        public IActionResult Index()
        {
            var crusts = FECrustClient.GetCrusts();
            return View(crusts);
        }
    }
}
