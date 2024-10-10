using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Models;
using spapp.ModelViews;
using System.Text.Json;
using System.Text.Json.Serialization;
using spapp.Http.Services;
using spapp.Http.Response;
using spapp.Helpers.Repository.Config;

namespace spapp.Controllers
{
    public class MunicipalityController(
        ICityRepository cityRepository,
        IMunicipalityRepository municipalityRepository,
        IConfigService configService
        ) : Controller
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly IConfigService _config = configService;


        [HttpGet]
        [Route("/municipal")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<MunicipalityModel> municipalities = await _municipalityRepository
                    .GetAllMunicipalityAsync();
                return View(municipalities);

            }catch( Exception ex )
            {
                TempData["EroorMessage"] = $"une erreure survenue pour lister les communes{ex.Message}";
                return View(nameof(Index));
            }
        }


        [HttpGet]
        [Route("/municipal/creer")]
        public async Task<IActionResult> Create(HttpClient httpClient)
        {

            try
            {
                string ApiBaseUrl = _config.GetSpappApiBaseUrl();
                MunicipalityModelView municipalityModelView = new();
                List<CityModel>? Cities = await _cityRepository.GetAllCitiesAsync(httpClient, ApiBaseUrl);

                foreach (CityModel city in Cities!)
                {
                    municipalityModelView.Cities.Add(city);
                }
                return View(municipalityModelView);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost]
        [Route("/municipal/creer")]
        public async Task<IActionResult> Create(MunicipalityModelView municipalityModelView, HttpClient httpClient)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string ApiBaseUrl = _config.GetSpappApiBaseUrl();
                    MunicipalityModelView data = await _municipalityRepository
                        .SetMunicipalityModelView(_cityRepository, httpClient, ApiBaseUrl);
                    return View(data);
                }
                await _municipalityRepository.CreateAsync(municipalityModelView);
                TempData["SuccessMessage"] = $"enregistrée avec succées";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["EroorMessage"] = $"une erreure survenue (post municipality) {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("/api/municipality/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve,
                    WriteIndented = true // Opcional, mas ajuda a formatar o JSON
                };
                MunicipalityModel finded = await _municipalityRepository.FindAsync(Id);
                
                return Json(Results.Ok(JsonSerializer.Serialize(finded, options)));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound<string>($"La commune n'existe pas : {ex.Message}"));
            }
        }

        [HttpPut]
        [Route("/api/municipality")]
        public async Task<JsonResult> Update([FromBody] MunicipalityModel model)
        {
            try
            {
                if (model is not null)
                {
                    await _municipalityRepository.UpdateAsync(model);
                    return Json(Results.Ok("Commune actualisée avec succés"));
                }

                return Json(Results.NoContent());
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500), ex.Message);
            }
        }

        [HttpDelete]
        [Route("/api/municipality/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                await _municipalityRepository.DeleteAsync(Id);
                return Json(Results.Ok("La commune a té supprimée"));
            }
            catch (Exception ex)
            {
                return Json(Results.NotFound<string>($"donnée introuvable ou une erreure du serveur : {ex.Message}"));
            }
        }

        [HttpGet]
        [Route("/api/municipality-by-city/{Id}")]
        public async Task<JsonResult> GetMunicipalitiesByCityId(int Id)
        {
            try
            {
                List<MunicipalityModel> results = await _municipalityRepository
                    .GetMunicipalitiesByCityAsync(Id);

                return Json(Results.Ok(results));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }

        [HttpGet]
        [Route("/api/municipality")]
        public async Task<JsonResult> GetAllApi()
        {
            try
            {
                List<MunicipalityModel> municipalities = await _municipalityRepository
                    .GetAllMunicipalityAsync();

                return Json(Results.Ok(MunicipalityResponse.AsModelListResponse(municipalities)));

            }
            catch (Exception ex)
            {
                return Json(Results.StatusCode(500), ex.Message);
            }
        }
    }
}
