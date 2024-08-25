using Microsoft.EntityFrameworkCore;
using spapp.Http.Response;
using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Vehicle
{
    public class VehicleRepository(SpappContextDb spappContextDb) : IVehicleRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;

        public async Task<VehicleModel> CreateAsync(VehicleModelView model)
        {
            VehicleModel entity = new()
            {
                LicensePlate = model.LicensePlate,
                Year = model.Year,
                KM = model.KM,
                Remark = model.Remark,
                VehicleBrandId = model.VehicleBrandId,
                Model = model.Model,
                Created_at = DateTime.Now
            };

            _spappContextDb.Vehicles.Add(entity);
            await _spappContextDb.SaveChangesAsync();
            return entity;
        }

        public async Task<List<VehicleModel>> GetAllAsync()
        {
            return await _spappContextDb.Vehicles
                .Include(vehicle => vehicle.VehicleBrandModel)
                .ToListAsync();
        }

        public async Task<VehicleModelView> SetVehicleModelView(IVehicleBrandRepository vehicleBrandRepository)
        {
            VehicleModelView instance = new();
            await instance.SetVehicleBrands(vehicleBrandRepository);
            return instance;
        }
    }
}
