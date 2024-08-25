using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.VehicleBrand
{
    public class VehicleBrandRepository(SpappContextDb spappContextDb) : IVehicleBrandRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;

        public async Task<List<VehicleBrandModel>> GetAllAsync()
        {
            return await _spappContextDb.VehicleBrands.ToListAsync();
        }
    }
}
