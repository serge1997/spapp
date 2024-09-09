using Microsoft.EntityFrameworkCore;
using spapp.Http.Requests;
using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Main.Repositories.PatrolMember;
using spapp.Main.Repositories.PatrolMunicipality;
using spapp.Main.Repositories.PatrolNeighborhood;
using spapp.Main.Repositories.PatrolNeighborhoodSector;
using spapp.Main.Repositories.Vehicle;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Patrol
{
    public class PatrolRepository(
        SpappContextDb spappContextDb,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        INeighborhoodSectorRepository neighborhoodSectorRepository,
        IVehicleRepository vehicleRepository,
        IAgentRepository agentRepository
     ) : IPatrolRepository
    {

        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighborhoodRepository = neighborhoodRepository;
        private readonly IVehicleRepository _vehicleRepository = vehicleRepository;
        private readonly INeighborhoodSectorRepository _neighborhoodSectorRepository = neighborhoodSectorRepository;
        private readonly IAgentRepository _agentRepository = agentRepository;


        public async Task<PatrolModel> CreateAsync(
           PatrolRequest request,
           IPatrolMunicipalityRepository patrolMunicipalityRepository,
           IPatrolNeighborhoodRepository patrolNeighborhoodRepository,
           IPatrolNeighborhoodSectorRepository patrolNeighborhoodSectorRepository,
           IPatrolMemberRepository patrolMemberRepository
        )
        {
            PatrolModel patrol = new()
            {
                Name = request.Name,
                Observation = request.Observation,
                DriverId = request.DriverId,
                VehicleId = request.VehicleId,
                Created_at = DateTime.Now
            };

            _spappContextDb.Patrols.Add(patrol);
            await _spappContextDb.SaveChangesAsync();

            
            patrolMunicipalityRepository.Create(request, patrol);
            patrolNeighborhoodRepository.Create(request, patrol);
           
            patrolNeighborhoodSectorRepository.Create(request, patrol);
            
            patrolMemberRepository.Create(request, patrol);

            return patrol;
        }

        public async Task<List<PatrolModel>> GetAllAsync()
        {
            return await _spappContextDb.Patrols
                .Include(patrol => patrol.Driver)
                .Include(patrol => patrol.PatrolMembers)
                    .ThenInclude(member => member.Agent)
                .Include(patrol => patrol.PatrolMunicipalities)
                    .ThenInclude(mun => mun.Municipality)
                .Include(patrol => patrol.PatrolNeighborhoods)
                    .ThenInclude(nei => nei.Neighborhood)
                .Include(patrol => patrol.PatrolNeighborhoodSectors)
                    .ThenInclude(sector => sector.NeighborhoodSector)
                .ToListAsync();
        }
        public async Task<PatrolModelView> SetPatrolModelView()
        {
            PatrolModelView instance = new();
            instance.Vehicles = await _vehicleRepository.GetAllAsync();
            instance.Neighborhoods = await _neighborhoodRepository.GetAllAsyncNeighborhood();
            instance.NeighborhoodSectors = await _neighborhoodSectorRepository.GetAllAsync();
            instance.Municipalities = await _municipalityRepository.GetAllMunicipalityAsync();
            instance.Agents = await _agentRepository.GetAllAsync();

            return instance;
        }
    }
}
