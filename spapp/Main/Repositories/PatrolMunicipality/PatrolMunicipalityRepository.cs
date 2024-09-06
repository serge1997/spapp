using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.PatrolMunicipality
{
    public class PatrolMunicipalityRepository(SpappContextDb spappContextDb) : IPatrolMunicipalityRepository
    {

        private readonly SpappContextDb _spappContextDb = spappContextDb;

        public void Create(PatrolRequest request, PatrolModel patrol)
        {
            
            if (request.MunicipalitiesId!.Length >= 1)
            {
                foreach (int id in request.MunicipalitiesId)
                {
                    PatrolMunicipalityModel model = new();
                    model.MunicipalityId = id;
                    model.PatrolId = patrol.Id;
                    model.Created_at = DateTime.Now;

                    _spappContextDb.PatrolMunicipalities.Add(model);
                    _spappContextDb.SaveChanges();

                }
            }
        }
    }
}
