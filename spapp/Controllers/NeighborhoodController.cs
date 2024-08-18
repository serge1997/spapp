using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.ModelViews;
using spapp.Http.Services;
using spapp.Models;
using System.Text.Json;

namespace spapp.Controllers
{
    public class NeighborhoodController(
        ICityRepository cityRepository,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository
        ) : Controller
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;



        [HttpGet]
        [Route("/neighborhood")]
        public async Task<IActionResult> Index()
        {
            List<NeighborhoodModel> results = await _neighborhoodRepository
                    .GetAllAsyncNeighborhood();
            return View(results);
        }

        [HttpGet]
        [Route("/neighborhood/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                NeighborhoodModelView neighborhoodModelView = new();
                await neighborhoodModelView.SetCities(_cityRepository);
                await neighborhoodModelView.SetMunicipalities(_municipalityRepository);

                return View(neighborhoodModelView);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }


        [HttpPost]
        [Route("/neighborhood/create")]
        public async Task<IActionResult> Create(NeighborhoodModelView neighborhoodModelView)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _neighborhoodRepository.CreateAsync(neighborhoodModelView);
                    TempData["SuccessMessage"] = "Quartier enregistré avec succés";
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Create));
            }
            catch(Exception ex)
            {
                TempData[""] = $"une erreure survenue {ex.Message}";
                return View(nameof(Create));
            }
        }

        [HttpGet]
        [Route("/api/neighborhood/{Id}")]
        public async Task<JsonResult> FindById(int Id)
        {
            try
            {
                NeighborhoodModel result = await _neighborhoodRepository
                    .FindNeighborhoodByIdAsync(Id);
                return Json(Results.Ok(JsonSerializer.Serialize(result, EntitiesRelatedJsonSerializer.RelatedToSerialize())));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex.Message));
            }
        }

        [HttpPut]
        [Route("/api/neighborhood")]
        public async Task<JsonResult> Update([FromBody]NeighborhoodModel neighborhoodModel)
        {
            try
            {
                if (neighborhoodModel is not null)
                {
                    await _neighborhoodRepository.UpdateAsync(neighborhoodModel);

                    return Json(Results.Ok("Le quartier a été actualisé"));
                }

                return Json(Results.NotFound());
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }

        [HttpDelete]
        [Route("/api/neighborhood/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                await _neighborhoodRepository.DeleteAsync(Id);
                return Json(Results.Ok("Quartier supprimé avec succés"));
            }
            catch(Exception ex)
            {
                return Json(Results.UnprocessableEntity(ex.Message));
            }
        }
        
    }
}
