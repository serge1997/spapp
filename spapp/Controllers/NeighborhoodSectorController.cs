using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Http.Services;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Models;
using spapp.ModelViews;

namespace spapp.Controllers
{

    public class NeighborhoodSectorController(
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        INeighborhoodSectorRepository neighborhoodSectorRepository
        ) : Controller
    {
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;
        private readonly INeighborhoodSectorRepository _neighborhoodSectorRepository = neighborhoodSectorRepository;

        [HttpGet]
        [Route("/neighborhood-sector")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<NeighborhoodSectorModel> results = await _neighborhoodSectorRepository
                    .GetAllAsync();

                return View(NeighborhoodSectorResponse.AsModelListResponse(results));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Impossible de lister les secteurs: {ex.Message}";
                return View();
            }
        }

        [HttpGet]
        [Route("/neighborhood-sector/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                
                NeighborhoodSectorModelView instance = await _neighborhoodSectorRepository
                    .SetNeighborhoodSectorModelView(_municipalityRepository, _neighborhoodRepository);

                return View(instance);
                
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure est survenue: {ex.Message}";
                return View();
            }
        }

        [HttpPost]
        [Route("/neighborhood-sector/create")]
        public async Task<IActionResult> Create(NeighborhoodSectorModelView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = $"Secteur enregistré avec succès";
                    await _neighborhoodSectorRepository.CreateAsync(model);
                    
                    return RedirectToAction(nameof(Index));
                }

                NeighborhoodSectorModelView instance = await _neighborhoodSectorRepository
                    .SetNeighborhoodSectorModelView(_municipalityRepository, _neighborhoodRepository);

                return View(instance);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une erreure est survenue (create sector): {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("/api/neighborhood-sector/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                NeighborhoodSectorModel result = await _neighborhoodSectorRepository
                    .FindAsync(Id);
            
                return Json(Results.Ok(NeighborhoodSectorResponse.AsModelResponse(result)));
            }
            catch( Exception ex )
            {
                return Json(Results.NotFound());
            }
        }

        [HttpPut]
        [Route("/api/neighborhood-sector")]
        public async Task<JsonResult> Update([FromBody]NeighborhoodSectorRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string message = "Secteur a été actualisé avec succès";
                    await _neighborhoodSectorRepository.UpdateAsync(request);
                    return Json(Results.Ok(message));
                }
                return Json(Results.BadRequest(ModelState));
            }
            catch(Exception ex)
            {
                return Json(Results.BadRequest($"une erreure est survenue: {ex.Message}"));
            }
        }

        [HttpDelete]
        [Route("/api/neighborhood-sector/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                string message = "Le secteur a été supprimé";

                await _neighborhoodSectorRepository.DeleteAsync(Id);
                return Json(Results.Ok(message));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex.Message));
            }
        }
    }
}
