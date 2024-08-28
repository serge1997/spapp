using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Main.Repositories.Vehicle;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Patrol
{
    public class PatrolRepository(
        SpappContextDb spappContextDb,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        INeighborhoodSectorRepository neighborhoodSectorRepository,
        IVehicleRepository vehicleRepository
     ) : IPatrolRepository
    {

        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly INeighborhoodSectorRepository _neighborhoodSectorRepository = neighborhoodSectorRepository;

        public async Task<PatrolModelView> SetPatrolModelView(
            IMunicipalityRepository municipalityRepository,
            INeighborhoodRepository neighborhoodRepository,
            INeighborhoodSectorRepository neighborhoodSectorRepository,
            IVehicleRepository vehicleRepository
        )
        {
            PatrolModelView instance = new();
            instance.Vehicles = await _vehicleRepository.GetAllAsync();
            instance.Neighborhoods = await _neighborhoodRepository.GetAllAsyncNeighborhood();
            instance.NeighborhoodSectors = await _neighborhoodSectorRepository.GetAllAsync();
            instance.Municipalities = await _municipalityRepository.GetAllMunicipalityAsync();

            return instance;
        }
    }
}
