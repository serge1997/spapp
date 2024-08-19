using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.ComplainTypeCategory;

namespace spapp.Controllers
{
    public class ComplainTypeCategoryController(IComplainTypeCategoryRepository complainTypeCategoryRepository) : Controller
    {
        private readonly IComplainTypeCategoryRepository complainTypeCategoryRepository1 = complainTypeCategoryRepository;

        public IActionResult Index()
        {
            return View();
        }
    }
}
