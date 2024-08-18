using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Neighborhood
{
    public class NeighborhoodRepository(SpappContextDb spappContextDb) : INeighborhoodRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        public async Task<NeighborhoodModel> CreateAsync(NeighborhoodModelView model)
        {
           NeighborhoodModel instance = new()
           {
               Name = model.Name,
               CityId = model.CityId,
               MunicipalityId = model.MunicipalityId,
               Latitude = model.Latitude,
               Longitude = model.Longitude,
               Updated_at = DateTime.Now,
           };

           _spappContextDb.Neighborhoods.Add(instance);
           await _spappContextDb.SaveChangesAsync();
           return instance;
        }

        public async Task<List<NeighborhoodModel>> GetAllAsyncNeighborhood()
        {
            return await _spappContextDb.Neighborhoods
                .Include(nei => nei.City)
                .Include(nei => nei.Municipality)
                .ToListAsync();
        }

        public async Task<NeighborhoodModel> FindNeighborhoodByIdAsync(int Id)
        {
            NeighborhoodModel finded = await _spappContextDb.Neighborhoods
                .Include(nei => nei.City)
                .Include(nei => nei.Municipality)
                .FirstOrDefaultAsync(nei => nei.Id == Id);

            return finded;
        }

        public async Task<NeighborhoodModel> UpdateAsync(NeighborhoodModel neighborhood)
        {
            NeighborhoodModel model = await FindNeighborhoodByIdAsync(neighborhood.Id);

            model.Name = neighborhood.Name;
            model.Latitude = neighborhood.Latitude;
            model.Longitude = neighborhood.Longitude;
            model.Population = neighborhood.Population;
            model.Updated_at = DateTime.Now;

            _spappContextDb.Neighborhoods.Update(model);
            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<NeighborhoodModel> DeleteAsync(int Id)
        {
            NeighborhoodModel finded = await FindNeighborhoodByIdAsync(Id);

            _spappContextDb.Neighborhoods.Remove(finded);
            await _spappContextDb.SaveChangesAsync();

            return finded;
        }
    }
}
