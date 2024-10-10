using Microsoft.EntityFrameworkCore;
using spapp.Main.Repositories.City;
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
            BeforeSave(model.Name, model.CityId);
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

        public MunicipalityModel? FindByNameAndCity(string Name, int City)
        {
            return _spappContext.Municipalities
                .FirstOrDefault(mun => mun.Name.Equals(Name) && mun.CityId == City)!;
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

        public async Task<MunicipalityModelView> SetMunicipalityModelView(ICityRepository cityRepository, HttpClient httpClient, string baseUrl)
        {
            MunicipalityModelView instance = new();
            instance.Cities = await cityRepository.GetAllCitiesAsync(httpClient, baseUrl);

            return instance;
            
        }

        public void BeforeSave(string Name, int City)
        {
            MunicipalityModel? finded = FindByNameAndCity(Name, City);

            if (finded is not null)
            {
                if (finded.CityId == City && finded.Name.Equals(Name)) 
                {
                    throw new Exception($"La commune {Name} existe dejá dans le systeme");
                }
            }
        }
    }
}
