using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PrzychodniaFinal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PrzychodniaFinal.Controllers
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
        public IActionResult ContactForm()
        {
            return View();
        }
        public IActionResult PacjentIndex()
        {
            return View("~/Views/Pacjencis/Index.cshtml");
        }
        public IActionResult PacjentCreate()
        {
            return View("~/Views/Pacjencis/Create.cshtml");
        }
        public IActionResult PacjentDelete()
        {
            return View("~/Views/Pacjencis/Delete.cshtml");
        }
        public IActionResult PacjentDetails()
        {
            return View("~/Views/Pacjencis/Details.cshtml");
        }
        public IActionResult PacjentEdit()
        {
            return View("~/Views/Pacjencis/Edit.cshtml");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
