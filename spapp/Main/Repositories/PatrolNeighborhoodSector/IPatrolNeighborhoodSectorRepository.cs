using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolNeighborhoodSector
{
    public interface IPatrolNeighborhoodSectorRepository
    {

        void Create(PatrolRequest request, PatrolModel patrol);
    }
}
