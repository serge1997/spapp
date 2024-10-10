using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using spapp.Helpers.Repository.Config;
using spapp.Http.Requests;
using spapp.Main.Repositories.City;
using spapp.Models;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace spapp.Controllers
{
  
    public class CityController(
        ICityRepository cityRepository,
        IConfigService configService
        ) : Controller
    {
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IConfigService _config = configService;


        [HttpGet]
        [Route("/ville")]
        public async Task<IActionResult> Index(HttpClient httpClient)
        {
            string ApiBaseUrl = _config.GetSpappApiBaseUrl();
            List<CityModel>? cities = await _cityRepository.GetAllCitiesAsync(httpClient, ApiBaseUrl);
            return View(cities);
        }

        [HttpGet]
        [Route("/ville/creer")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/ville/creer")]
        public async Task<IActionResult> Create(CityModel city, HttpClient httpClient)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    string ApiBaseUrl = _config.GetSpappApiBaseUrl();
                    var response = await _cityRepository.CreateCityAsync(city, ApiBaseUrl,httpClient);
                    TempData["SuccessMessage"] = $"{response!.Message}";
                    return RedirectToAction(nameof(Index));
                }
                return View(nameof(Create));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Erreure du service: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("/api/ville/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                CityModel city = await _cityRepository.FindCityAsync(Id);
                return Json(city);
            }
            catch (Exception ex)
            {
                return Json($"Une erreure est survenue");
            }
        }

        [HttpPut]
        [Route("/api/ville")]
        public async Task<JsonResult> Update([FromBody]CityRequest Request)
        {
          

            try
            {
                if (Request is not null)
                {
                    await _cityRepository.UpdateAsync(Request);
                    return Json(Results.Ok("Ville actualisée avec succés"));
                }
                return Json(Results.NoContent());
            }
            catch(Exception ex)
            {
                return Json($"une erreure est survenue");
            }
        }

        [HttpDelete]
        [Route("/api/ville/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                await _cityRepository.DeleteAsync(Id);
                return Json(Results.Ok("Ville supprimée avec succées"));
            }
            catch(Exception ex)
            {
                return Json(Results.UnprocessableEntity($"Une erreure est survenue {ex.Message}"));
            }
        }

        [HttpGet]
        [Route("/api/city")]
        public async Task<JsonResult> IndexApi(HttpClient httpClient)
        {
            string ApiBaseUrl = _config.GetSpappApiBaseUrl();
            var cities = await _cityRepository.GetAllCitiesAsync(httpClient, ApiBaseUrl);
            return Json(Results.Ok(cities));
        }
    }
}
