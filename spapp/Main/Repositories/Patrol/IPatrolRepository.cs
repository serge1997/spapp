using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Main.Repositories.Vehicle;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Patrol
{
    public interface IPatrolRepository
    {

        Task<PatrolModelView> SetPatrolModelView();
    }
}
