using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Municipality
{
    public class MunicipalityRepository(SpappContextDb spappContextDb) : IMunicipalityRepository
    {
        private readonly SpappContextDb _spappContext = spappContextDb;

        public async Task<MunicipalityModel> CreateAsync(MunicipalityModelView model)
        {
            MunicipalityModel municpal = new()
            {
                Name = model.Name,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Created_at = DateTime.Now,
                Population = model.Population,
                CityId = model.CityId,
            };

            _spappContext.Municipalities.Add(municpal);
            await _spappContext.SaveChangesAsync();
            return municpal;
        }

        public async Task<List<MunicipalityModel>> GetAllMunicipalityAsync()
        {
            List<MunicipalityModel> entities = await _spappContext
                .Municipalities
                .Include(mun => mun.City)
                .ToListAsync();
            return entities;
        }

        public async Task<MunicipalityModel> FindAsync(int Id)
        {
            return await _spappContext.Municipalities
                .Include(mun => mun.City)
                .FirstOrDefaultAsync(m => m.Id == Id);
        }

        public async Task<MunicipalityModel> UpdateAsync(MunicipalityModel model)
        {
            MunicipalityModel finded = await FindAsync(model.Id);
            finded.Population = model.Population;
            finded.Name = model.Name;
            finded.Latitude = model.Latitude;
            finded.Longitude = model.Longitude;
            finded.Updated_at = DateTime.Now;

            _spappContext.Municipalities.Update(finded);
            await _spappContext.SaveChangesAsync();

            return finded;
        }


        public async Task<MunicipalityModel> DeleteAsync(int Id)
        {
            MunicipalityModel model = await FindAsync(Id);
            _spappContext.Municipalities.Remove(model);
            await _spappContext.SaveChangesAsync();
            return model;
        }

        public async Task<List<MunicipalityModel>> GetMunicipalitiesByCityAsync(int Id)
        {

            return await _spappContext.Municipalities
                 .Where(m => m.CityId == Id)
                 .ToListAsync();

        }
    }
}
