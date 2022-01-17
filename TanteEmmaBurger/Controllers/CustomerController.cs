using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanteEmmaBurger.Data;
using TanteEmmaBurger.Models;
using TanteEmmaBurger.Controllers;

namespace TanteEmmaBurger.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CreateOrder(int id)
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }
    }
}
