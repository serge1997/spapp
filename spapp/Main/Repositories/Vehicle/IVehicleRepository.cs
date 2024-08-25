using spapp.Http.Response;
using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;
using spapp.ModelViews;
using spapp.Http.Requests;

namespace spapp.Main.Repositories.Vehicle
{
    public interface IVehicleRepository
    {

        Task<VehicleModel> CreateAsync(VehicleModelView model);
        Task<List<VehicleModel>> GetAllAsync();
        Task<VehicleModel> FindVehicle(int Id);
        Task<VehicleModel> UpdateAsync(VehicleRequest request);
        Task<VehicleModelView> SetVehicleModelView(IVehicleBrandRepository vehicleBrandRepository);
        Task<VehicleModel> DeleteAsync(int Id);
    }
}
