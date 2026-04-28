using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace task1.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context = new AppDbContext();

        // GET: Order
        public IActionResult Index()
        {
            ViewBag.Customers = new SelectList(_context.Customers.ToList(), "Id", "Name");

            return View(_context.Orders.Include(o => o.Customer).ToList());
        }

        // POST: Order
        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {   
            try
            {
                var selectedCustomerId = int.Parse(collection["CustomerId"]);

                var selectedCustomer = _context.Customers
                        .FirstOrDefault(c => c.Id == selectedCustomerId);

                ViewBag.Customers = new SelectList(_context.Customers.ToList(), "Id", "Name", selectedCustomerId);

                return View(_context.Orders.Include(o => o.Customer).Where(o => o.CustomerId == selectedCustomerId).ToList());
            }
            catch
            {
                ViewBag.Customers = new SelectList(_context.Customers.ToList(), "Id", "Name");
                
                return View(_context.Orders.Include(o => o.Customer).ToList());
            }

        }


        // GET: Order/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Date,TotalPrice,CustomerId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["Customers"] = new SelectList(_context.Customers, "Id", "Name", order.CustomerId);
            return View(order);
        }

        // GET: Order/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", order.CustomerId);
            return View(order);
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,TotalPrice,CustomerId")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Email", order.CustomerId);
            return View(order);
        }

        // GET: Order/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .Include(o => o.Customer)
                .FirstOrDefault(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
