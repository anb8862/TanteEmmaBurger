using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanteEmmaBurger.Data;
using TanteEmmaBurger.Models;

namespace TanteEmmaBurger.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            ViewBag.Orders = orders;
            return View();
        }

        [Authorize(Roles = "Waiter")]

        public IActionResult CreateOrder(int id)
        {
            if (id==0)
            {
                return View("CreateOrder");
            }

            var orderInDb = _context.Orders.Find(id);
            if (orderInDb == null)
            {
                return NotFound();
            }
            return View("CreateOrder", orderInDb);
        }

        [HttpPost]
        public IActionResult CreateOrderFood(Order order)
        {
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            } else
            {
                _context.Orders.Update(order);
            }
            
            _context.SaveChanges();
            return RedirectToAction ("Index");
        }

        public IActionResult DeleteOrder(int id)
        {
            var orderInDb = _context.Orders.Find(id);

            if (orderInDb == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orderInDb);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
