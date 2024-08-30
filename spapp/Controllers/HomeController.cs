using Microsoft.AspNetCore.Mvc;
using spapp.Models;
using System.Diagnostics;

namespace spapp.Controllers
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
            string name = "Serge Gogo";
            string first = name.Split(" ")[0];

            string protocol = first[0] + DateTime.Now
                .ToString("dd/MM/yyyyHHmmssfff")
                .Replace("/", "");
            

            TempData["protocol"] = protocol;

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
