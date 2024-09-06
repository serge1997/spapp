using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.PatrolNeighborhoodSector
{
    public class PatrolNeighborhoodSectorRepository(SpappContextDb spappContextDb) : IPatrolNeighborhoodSectorRepository
    {

        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public void Create(PatrolRequest request, PatrolModel patrol)
        {
            if(request.NeighbordhoodSectorsId!.Length >= 1)
            {
                foreach (int id in request.NeighbordhoodSectorsId)
                {
                    PatrolNeighborhoodSectorModel model = new();
                    model.PatrolId = patrol.Id;
                    model.NeighbordhoodSectorId = id;
                    model.Created_at = DateTime.Now;
                    
                    _spappContextDb.PatrolNeighborhoodSectors.Add(model);
                    _spappContextDb.SaveChanges();
                }
            }

        }
    }
}
