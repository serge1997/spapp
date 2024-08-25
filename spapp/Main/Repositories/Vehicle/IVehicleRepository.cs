using spapp.Http.Response;
using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Vehicle
{
    public interface IVehicleRepository
    {

        Task<VehicleModel> CreateAsync(VehicleModelView model);
        Task<List<VehicleModel>> GetAllAsync();
        Task<VehicleModelView> SetVehicleModelView(IVehicleBrandRepository vehicleBrandRepository);
    }
}
