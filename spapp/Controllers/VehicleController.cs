using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.Vehicle;
using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;
using spapp.ModelViews;
using spapp.Http.Response;
using spapp.Http.Requests;
using spapp.Http.Services;

namespace spapp.Controllers
{
    public class VehicleController(IVehicleBrandRepository vehicleBrandRepository, IVehicleRepository vehicleRepository) : Controller
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository = vehicleBrandRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;

        [HttpGet]
        [Route("/vehicle")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<VehicleModel> results = await _vehicleRepository.GetAllAsync();

                return View(new VehicleResponse().AsModelResponseList(results));
            }
            catch(Exception ex)
            {
                TempData["ErrorMssage"] = $"erreur pour lister les vehicules de patrouille: ${ex.Message}";
                return View();
            }
        }

        [HttpGet]
        [Route("/api/vehicle/{Id}")]
        public async Task<JsonResult> Find(int Id)
        {
            try
            {
                VehicleModel finded = await _vehicleRepository.FindVehicle(Id);

                return Json(new VehicleResponse().AsModelResponse(finded), EntitiesRelatedJsonSerializer.RelatedToSerialize());
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex.Message));
            }
        }

        [HttpGet]
        [Route("/vehicle/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                VehicleModelView model = await _vehicleRepository
                    .SetVehicleModelView(_vehicleBrandRepository);

                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure survenue {ex.Message}";
                return View(nameof(Index));
            }
        }

        [HttpPost]
        [Route("/vehicle/create")]
        public async Task<IActionResult> Create(VehicleModelView modelView)
        {
            try
            {
               if (ModelState.IsValid)
               {
                    TempData["SuccessMessage"] = "Vehicule de patrouille enregistré";
                    await _vehicleRepository.CreateAsync(modelView);
                    return RedirectToAction(nameof(Index));
               }
                VehicleModelView instance = await _vehicleRepository.SetVehicleModelView(_vehicleBrandRepository);
                return View(instance);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"une erreure est survenue: {ex.ToString()}";
                return View(nameof(Index)); ;
            }
        }

        [HttpPut]
        [Route("/api/vehicle")]
        public async Task<IActionResult> Update([FromBody]VehicleRequest request)
        {
            try
            {
                string message = "Vehicule actualisée avec succès";
                await _vehicleRepository.UpdateAsync(request);

                return Json(Results.Ok(message));
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500));
            }
        }

        [HttpDelete]
        [Route("/api/vehicle/{Id}")]
        public async Task<JsonResult> Delete(int Id)
        {
            try
            {
                string message = "Vehicule supprimé avec succès";
                await _vehicleRepository.DeleteAsync(Id);

                return Json(Results.Ok(message));
            }
            catch(Exception ex)
            {
                return Json(Results.StatusCode(500), ex.Message);
            }

        }
    }
}
