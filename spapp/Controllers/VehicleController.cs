using Microsoft.AspNetCore.Mvc;

namespace spapp.Controllers
{
    public class VehicleController : Controller
    {

        [HttpGet]
        [Route("/vehicle")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/vehicle/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
