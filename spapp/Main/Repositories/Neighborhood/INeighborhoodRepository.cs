using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Neighborhood
{
    public interface INeighborhoodRepository
    {

        Task<NeighborhoodModel> CreateAsync(NeighborhoodModelView neighborhood);
        Task<List<NeighborhoodModel>> GetAllAsyncNeighborhood();
        Task<NeighborhoodModel> FindNeighborhoodByIdAsync(int Id);
        Task<NeighborhoodModel> UpdateAsync(NeighborhoodModel neighborhood);
        Task<List<NeighborhoodModel>> GetAllByMunicipality(int Municipality);
        Task<NeighborhoodModel> DeleteAsync(int Id);
    }
}
