using Microsoft.AspNetCore.Mvc;

namespace spapp.Controllers
{
    public class ComplainController : Controller
    {

        [HttpGet]
        [Route("/complain")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/complain/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
