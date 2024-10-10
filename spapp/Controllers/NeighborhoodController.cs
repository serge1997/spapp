using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.ModelViews;
using spapp.Http.Services;
using spapp.Models;
using System.Text.Json;
using spapp.Http.Response;
using spapp.Helpers.Repository.Config;

namespace spapp.Controllers
{
    public class NeighborhoodController(
        ICityRepository cityRepository,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        IConfigService configService
        ) : Controller
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;
        private readonly IConfigService _config = configService;



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
        public async Task<IActionResult> Create(HttpClient httpClient)
        {
            try
            {
                string ApiBaseUrl = _config.GetSpappApiBaseUrl();
                NeighborhoodModelView neighborhoodModelView = new();
                await neighborhoodModelView.SetCities(_cityRepository, httpClient, ApiBaseUrl);
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

                return Json(Results.Ok(NeighborhoodResponse.AsModelResponse(result)));
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

        [HttpGet]
        [Route("/api/neighborhood-by-municipality/{Id}")]
        public async Task<JsonResult> GetByMunicipality(string Id)
        {
            try
            {
                string[] ids = Id.Split(',');
               
                List<NeighborhoodModel> results = await _neighborhoodRepository
                    .GetAllByMunicipality(ids);

                return Json(Results.Ok(NeighborhoodResponse.AsModelListResponse(results)));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex.ToString()));
            }
        }

        [HttpGet]
        [Route("/api/neighborhood")]
        public async Task<JsonResult> GetAllApi()
        {
            try
            {
                List<NeighborhoodModel> results = await _neighborhoodRepository
                    .GetAllAsyncNeighborhood();

                return Json(Results.Ok(NeighborhoodResponse.AsModelListResponse(results)));
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }

        [HttpGet]
        [Route("/api/neighborhood-by-name")]
        public async Task<JsonResult> GetByName([FromQuery] string name)
        {
            try
            {
                List<NeighborhoodModel> results = await _neighborhoodRepository
                    .FindByNameAsync(name);

                return Json(Results.Ok(NeighborhoodResponse.AsModelListResponse(results)));
            }
            catch (Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }

    }
}
