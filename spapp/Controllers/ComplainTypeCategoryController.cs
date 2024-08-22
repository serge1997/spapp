using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.Models;

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
                List<ComplainTypeCategoryModel> response = await _complainTypeCategoryRepository
                    .GetAllAsync();

                return View(new ComplainTypeCategoryResponse().AsModelListResponse(response));
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
                ComplainTypeCategoryModel finded = await _complainTypeCategoryRepository
                    .FindAsync(Id);

                return Json(Results.Ok(new ComplainTypeCategoryResponse().AsModelResponse(finded)));
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

        [HttpPut]
        [Route("/api/complaint-type-category")]
        public async Task<JsonResult> Update([FromBody] ComplainTypeCategoryRequest request)
        {
            try
            {
                await _complainTypeCategoryRepository.UpdateAsync(request); 
                return Json(Results.Ok("Categorie de type actualisée"));
            }
            catch(Exception ex)
            {
                return Json(Results.NoContent());
            }
        }

        [HttpGet]
        [Route("/api/complaint-type-category")]
        public async Task<JsonResult> GeAllApi()
        {
            try
            {
                List<ComplainTypeCategoryModel> result = await _complainTypeCategoryRepository
                    .GetAllAsync();

                return Json(Results.Ok(result));
            }
            catch( Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }
    }
}
