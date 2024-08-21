using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.ComplainType;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.ModelViews;

namespace spapp.Controllers
{
    public class ComplainTypeController(IComplainTypeRepository complainTypeRepository, IComplainTypeCategoryRepository complainTypeCategoryRepository) : Controller
    {
        private readonly IComplainTypeRepository _complainTypeRepository = complainTypeRepository;
        private readonly IComplainTypeCategoryRepository _complainTypeCategory = complainTypeCategoryRepository;

        [HttpGet]
        [Route("complain-type")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("complain-type/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                ComplainTypeModelView complainTypeModelView = new();
                await complainTypeModelView.SetComplainTypeCategory(_complainTypeCategory);

                return View(complainTypeModelView);

            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }
    }
}
