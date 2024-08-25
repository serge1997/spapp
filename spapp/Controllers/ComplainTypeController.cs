using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Main.Repositories.ComplainType;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.ModelViews;
using spapp.Models;
using spapp.Http.Response;
using System.Text.Json;
using spapp.Http.Services;

namespace spapp.Controllers
{
    public class ComplainTypeController(IComplainTypeRepository complainTypeRepository, IComplainTypeCategoryRepository complainTypeCategoryRepository) : Controller
    {
        private readonly IComplainTypeRepository _complainTypeRepository = complainTypeRepository;
        private readonly IComplainTypeCategoryRepository _complainTypeCategory = complainTypeCategoryRepository;

        [HttpGet]
        [Route("complain-type")]
        public async Task<IActionResult> Index()
        {
            try
            {
               List<ComplainTypeModel> results = await _complainTypeRepository.GellAllAsync();

                return View(new ComplainTypeResponse().AsModelResponseList(results));
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet]
        [Route("/complain-type/create")]
        public async Task<IActionResult> Create()
        {
            try
            {              
               
                  ComplainTypeModelView complainTypeModelView = await _complainTypeRepository
                    .SetCompolainTypeModelView(_complainTypeCategory);

                  return View(complainTypeModelView);           

            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure survenue {ex.Message}";
                return View(nameof(Index)); ;
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

                    return RedirectToAction(nameof(Index));
                }

                ComplainTypeModelView modelView = await _complainTypeRepository
                    .SetCompolainTypeModelView(_complainTypeCategory);
                return View(modelView);

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure survenue: {ex.ToString()}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("/api/complain-type/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                ComplainTypeModel finded = await _complainTypeRepository
                    .FindAsync(Id);

                return Json(Results.Ok(JsonSerializer.Serialize(finded, EntitiesRelatedJsonSerializer.RelatedToSerialize())));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound("Aucune donnée rencontrée"));
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

        [HttpDelete]
        [Route("/api/complain-type/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                await _complainTypeRepository.DeleteAsync(Id);

                return Json(Results.Ok("Type de complainte supprimée avec succés"));
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }
    }
}
