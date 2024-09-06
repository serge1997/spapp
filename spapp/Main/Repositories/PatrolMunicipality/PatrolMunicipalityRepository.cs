using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolMunicipality
{
    public class PatrolMunicipalityRepository : IPatrolMunicipalityRepository
    {


        public async Task CreateAsync(PatrolRequest request, PatrolModel patrol)
        {
            
            if (request.MunicipalitiesId!.Length >= 1)
            {
                foreach (int id in request.MunicipalitiesId)
                {
                    PatrolMunicipalityModel model = new();
                    model.MunicpalityId = id;
                    model.PatrolId = patrol.Id;
                    model.Created_at = DateTime.Now;
                }
            }
        }
    }
}
