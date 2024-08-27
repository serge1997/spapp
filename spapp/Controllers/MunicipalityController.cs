using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Models;
using spapp.ModelViews;
using System.Text.Json;
using System.Text.Json.Serialization;
using spapp.Http.Services;

namespace spapp.Controllers
{
    public class MunicipalityController(
        ICityRepository cityRepository,
        IMunicipalityRepository municipalityRepository
        ) : Controller
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;


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
        public async Task<IActionResult> Create()
        {

            try
            {
                MunicipalityModelView municipalityModelView = new();
                //municipalityModelView.Cities = new List<CityModel>();
                List<CityModel> Cities = await _cityRepository.GetAllCitiesAsync();

                foreach (CityModel city in Cities)
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
        public async Task<IActionResult> Create(MunicipalityModelView municipalityModelView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    MunicipalityModelView data = await _municipalityRepository
                        .SetMunicipalityModelView(_cityRepository);
                    return View(data);
                }
                await _municipalityRepository.CreateAsync(municipalityModelView);
                TempData["SuccessMessage"] = $"enregistrée avec succées {municipalityModelView.CityId}";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["EroorMessage"] = $"une erreure survenue {ex.Message}";
                return View(nameof(Create));
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
                return Json(Results.StatusCode(500));
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
                return Json(Results.Ok(municipalities));

            }
            catch (Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }
    }
}
