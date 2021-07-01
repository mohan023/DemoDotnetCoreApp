using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DemoDotnetCoreApplication.Models;
using Microsoft.Extensions.Configuration;

namespace DemoDotnetCoreApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _congi;

        public HomeController(ILogger<HomeController> logger, IConfiguration congi )
        {
            _logger = logger;
            _logger.LogInformation("Home Contoller Executed");
            _logger.LogDebug("Home Controller Debug Message");
            _congi = congi;
        }

        public IActionResult Index()
        {
            ViewData["MyKey"] = _congi["MyKey"].ToString();
            ViewData["ConnectionString"] = _congi["ConnectionString"].ToString();
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
    }
}
