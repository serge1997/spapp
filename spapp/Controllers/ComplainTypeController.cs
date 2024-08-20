using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.ComplainType;

namespace spapp.Controllers
{
    public class ComplainTypeController(IComplainTypeRepository complainTypeRepository) : Controller
    {
        private readonly IComplainTypeRepository _complainTypeRepository = complainTypeRepository;

        [HttpGet]
        [Route("complain-type")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("complain-type/create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
