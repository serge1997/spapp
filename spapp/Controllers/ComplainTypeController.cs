using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.ComplainType;

namespace spapp.Controllers
{
    public class ComplainTypeController(IComplainTypeRepository complainTypeRepository) : Controller
    {
        private readonly IComplainTypeRepository _complainTypeRepository = complainTypeRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
