using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_WEB_Project.Models; //ari ni kuha og models
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_WEB_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult OrderDetail(int orderId, DateTime dateTime, string customerName, decimal totalAmount)
        {

            var order = new Order
            {
                OrderNo = orderId,
                OrderDate = dateTime,
                CustomerName = customerName,
                TotalAmount = totalAmount,
            };

            return View(order);
        }

        public IActionResult Customers()
        {
            return View();
        }
    }
}
