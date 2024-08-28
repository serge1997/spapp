using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.ModelViews;
using spapp.Models;
using spapp.Http.Requests;

namespace spapp.Main.Repositories.NeighborhoodSector
{
    public interface INeighborhoodSectorRepository
    {
        Task<List<NeighborhoodSectorModel>> GetAllAsync();
        Task<NeighborhoodSectorModel> CreateAsync(NeighborhoodSectorModelView modelView);

        Task<NeighborhoodSectorModel> FindAsync(int Id);

        Task<NeighborhoodSectorModel> UpdateAsync(NeighborhoodSectorRequest request);

        Task<NeighborhoodSectorModelView> SetNeighborhoodSectorModelView(
            IMunicipalityRepository municipalityRepository,
            INeighborhoodRepository neighborhoodRepository
           );

        Task<NeighborhoodSectorModel> DeleteAsync(int Id);
    }
}
