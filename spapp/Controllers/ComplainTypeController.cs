using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
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
        [Route("/complain-type/create")]
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

        [HttpPost]
        [Route("/complain-type/create")]
        public async Task<IActionResult> Create(ComplainTypeModelView complainTypeModelView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _complainTypeRepository.CreateAsync(complainTypeModelView);
                    TempData["SuccessMessage"] = "Type de plainte crée avec succès";

                    return View(nameof(Index));
                }

                return View();

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPut]
        [Route("/api/complain-type")]
        public async Task<JsonResult> Update([FromBody]ComplainTypeRequest request)
        {
            try
            {
                await _complainTypeRepository.UpdateAsync(request);

                return Json(Results.Ok("Type de plainte actualisée avec succés"));

            }
            catch (Exception ex)
            {
                return Json(Results.StatusCode(404), ex.Message);
            }
        }
    }
}
