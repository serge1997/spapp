using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Main.Repositories.ComplainTypeCategory;

namespace spapp.Controllers
{
    public class ComplainTypeCategoryController(IComplainTypeCategoryRepository complainTypeCategoryRepository) : Controller
    {
        private readonly IComplainTypeCategoryRepository _complainTypeCategoryRepository = complainTypeCategoryRepository;

        [HttpGet]
        [Route("/complaint-type-category")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<ComplainTypeCategoryResource> response = await _complainTypeCategoryRepository
                    .GetAllAsync();

                return View(response);
            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        [Route("/complaint-type-category/create")]
        public IActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        [Route("/complaint-type-category/create")]
        public async Task<IActionResult> Create(ComplainTypeCategoryRequest Request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = "Categorie de type de crimes enregistré";
                    await _complainTypeCategoryRepository.CreateAsync(Request);
                    return RedirectToAction(nameof(Index));
                }

                return View(nameof(Create));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure est survenue : {ex.Message}";
                return View(nameof(Create));
            }
        }

        [HttpGet]
        [Route("/api/complaint-type-category/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                ComplainTypeCategoryResource finded = await _complainTypeCategoryRepository
                    .FindAsync(Id);

                return Json(Results.Ok(finded));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }

        [HttpDelete]
        [Route("/api/complaint-type-category/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                await _complainTypeCategoryRepository
                    .DeleteAsync(Id);

                return Json(Results.Ok("Categorie de type de crimes a été supprimé"));
            }
            catch (Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }
    }
}
