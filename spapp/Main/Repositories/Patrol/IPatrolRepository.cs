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

namespace spapp.Main.Repositories.Patrol
{
    public interface IPatrolRepository
    {

        Task<PatrolModel> CreateAsync(
           PatrolRequest request,
           IPatrolMunicipalityRepository patrolMunicipalityRepository,
           IPatrolNeighborhoodRepository patrolNeighborhoodRepository,
           IPatrolNeighborhoodSectorRepository patrolNeighborhoodSectorRepository,
           IPatrolMemberRepository patrolMemberRepository
        );
        Task<PatrolModelView> SetPatrolModelView();
    }
}
