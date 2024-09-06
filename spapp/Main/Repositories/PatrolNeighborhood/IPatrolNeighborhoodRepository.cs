using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolNeighborhood
{
    public interface IPatrolNeighborhoodRepository
    {

        void Create(PatrolRequest request, PatrolModel patrol);
    }
}
