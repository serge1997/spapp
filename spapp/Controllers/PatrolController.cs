using Microsoft.AspNetCore.Mvc;

namespace spapp.Controllers
{
    public class PatrolController : Controller
    {

        [HttpGet]
        [Route("/patrouille")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/patrouille/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
