using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;

namespace spapp.Controllers
{
    public class VehicleBrandController(IVehicleBrandRepository vehicleBrandRepository) : Controller
    {
        private readonly IVehicleBrandRepository _vehicleBrandRepository = vehicleBrandRepository;
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/api/vehicle-brand")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<VehicleBrandModel> entities = await _vehicleBrandRepository
                    .GetAllAsync();

                return Json(Results.Ok(entities));
            }
            catch (Exception ex)
            {
                return Json(Results.NotFound());
            }
        }
    }
}
