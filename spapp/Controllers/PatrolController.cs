using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Main.Repositories.Patrol;
using spapp.Main.Repositories.Vehicle;
using spapp.ModelViews;

namespace spapp.Controllers
{
    public class PatrolController(
        IPatrolRepository patrol,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        INeighborhoodSectorRepository neighborhoodSectorRepository,
        IVehicleRepository vehicleRepository
    ) : Controller
    {
        private readonly IPatrolRepository _patrolRepository = patrol;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly INeighborhoodSectorRepository _neighborhoodSectorRepository = neighborhoodSectorRepository;

        [HttpGet]
        [Route("/patrol")]
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        [Route("/patrol/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                PatrolModelView patrolModelView = await _patrolRepository
                    .SetPatrolModelView(
                        _municipalityRepository,
                        _neighborhoodRepository,                        
                        _neighborhoodSectorRepository,
                        _vehicleRepository
                    );

                return View(patrolModelView);
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
