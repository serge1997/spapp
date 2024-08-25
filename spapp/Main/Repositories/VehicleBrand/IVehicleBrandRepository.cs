using spapp.Models;

namespace spapp.Main.Repositories.VehicleBrand
{
    public interface IVehicleBrandRepository
    {

        Task<List<VehicleBrandModel>> GetAllAsync();
    }
}
