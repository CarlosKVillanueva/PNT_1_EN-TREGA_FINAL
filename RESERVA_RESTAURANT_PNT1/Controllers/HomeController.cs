using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RESERVA_RESTAURANT_PNT1.Models;

namespace RESERVA_RESTAURANT_PNT1.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}