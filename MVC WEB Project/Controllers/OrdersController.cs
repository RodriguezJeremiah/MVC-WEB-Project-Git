using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_WEB_Project.Data;
using MVC_WEB_Project.Models;

namespace MVC_WEB_Project.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MVCDbContext _context;

        public OrdersController(MVCDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string search)
        {
            IQueryable<Order> orders = _context.Order.Include(o => o.Customer).Include(o => o.OrderItems).ThenInclude(oi => oi.Product);

            if (!string.IsNullOrEmpty(search))
            {
                orders = orders.Where(o => o.Customer.CustomerName.Contains(search));
            }

            var orderList = await orders.ToListAsync();

            return View(orderList);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.OrderNo == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "ProductName");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                // Retrieve customer details based on selected CustomerId
                var selectedCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                order.CustomerName = selectedCustomer?.CustomerName;

                // Calculate total amount for each order item
                foreach (var orderItem in order.OrderItems)
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == orderItem.ProductId);
                    if (product != null)
                    {
                        // Calculate total amount for the order item
                        orderItem.TotalAmount = orderItem.Quantity * product.Price;

                        // Set the Price based on the selected product
                        orderItem.Price = product.Price;
                    }
                }

                // Calculate total amount for the order
                order.TotalAmount = order.OrderItems.Sum(oi => oi.TotalAmount);

                // Add the order to the context
                _context.Orders.Add(order);

                // Update stock
                foreach (var orderItem in order.OrderItems)
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == orderItem.ProductId);
                    if (product != null)
                    {
                        product.StockOnHand -= orderItem.Quantity;
                    }
                }

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "ProductName");

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.OrderNo == id);

            if (order == null)
            {
                return NotFound();
            }

            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "ProductName");

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                // Retrieve customer details based on selected CustomerId
                var selectedCustomer = _context.Customers.FirstOrDefault(c => c.CustomerId == order.CustomerId);
                order.CustomerName = selectedCustomer?.CustomerName;

                // Update stock and create order items
                foreach (var orderItem in order.OrderItems)
                {
                    var product = _context.Products.FirstOrDefault(p => p.ProductId == orderItem.ProductId);
                    if (product != null)
                    {
                        // Update stock
                        product.StockOnHand -= orderItem.Quantity;

                        // Calculate total amount for the order item
                        orderItem.TotalAmount = orderItem.Quantity * product.Price;
                    }
                }

                // Update order in the context
                _context.Update(order);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Customers = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewBag.Products = new SelectList(_context.Products, "ProductId", "ProductName");

            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.OrderNo == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(m => m.OrderNo == id);

            // Restore stock
            foreach (var orderItem in order.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == orderItem.ProductId);
                if (product != null)
                {
                    product.StockOnHand += orderItem.Quantity;
                }
            }

            // Remove order from context
            _context.Order.Remove(order);

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Order.Any(e => e.OrderNo == id);
        }
    }
}
