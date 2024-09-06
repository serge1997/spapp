using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolMunicipality
{
    public interface IPatrolMunicipalityRepository
    {
        Task CreateAsync(PatrolRequest request, PatrolModel patrol);
    }
}
