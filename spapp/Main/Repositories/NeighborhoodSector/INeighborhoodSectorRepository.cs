using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.ModelViews;
using spapp.Models;

namespace spapp.Main.Repositories.NeighborhoodSector
{
    public interface INeighborhoodSectorRepository
    {
        Task<List<NeighborhoodSectorModel>> GetAllAsync();
        Task<NeighborhoodSectorModel> CreateAsync(NeighborhoodSectorModelView modelView);

        Task<NeighborhoodSectorModel> Find(int Id);

        Task<NeighborhoodSectorModelView> SetNeighborhoodSectorModelView(
            IMunicipalityRepository municipalityRepository,
            INeighborhoodRepository neighborhoodRepository
           );

        Task<NeighborhoodSectorModel> DeleteAsync(int Id);
    }
}
