using spapp.SpappContext;
using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.PatrolNeighborhood
{
    public class PatrolNeighborhoodRepository(SpappContextDb spappContextDb) : IPatrolNeighborhoodRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public void Create(PatrolRequest request, PatrolModel patrol)
        {
            if (request.NeighbordhoodsId is not null)
            {
                foreach (int id in  request.NeighbordhoodsId)
                {
                    PatrolNeighborhoodModel model = new();
                    model.PatrolId = patrol.Id;
                    model.NeighbordhoodId = id;
                    model.Created_at = DateTime.Now;

                    _spappContextDb.PatrolNeighborhoods.Add(model);
                    _spappContextDb.SaveChanges();
                }
            }
          
        }
    }
}
