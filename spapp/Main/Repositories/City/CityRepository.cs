using Azure.Core;
using Microsoft.EntityFrameworkCore;
using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.City
{
    public class CityRepository(SpappContextDb spappContextDb) : ICityRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;

        public async Task<CityModel> CreateCityAsync(CityModel city)
        {
            BeforeSave(city.Name);
            CityModel model = new()
            {
                Name = city.Name,
                Region = city.Region,
                District = city.District,
                Population = city.Population,
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                Area = city.Area,
                Created_at = DateTime.Now
            };

            _spappContextDb.Cities.Add(model);
            await _spappContextDb.SaveChangesAsync();
            return city;
        }

        public async Task<List<CityModel>> GetAllCitiesAsync()
        {
            return await _spappContextDb.Cities.ToListAsync();
        }

        public async Task<CityModel> FindCityAsync(int Id)
        {
            return await _spappContextDb.Cities.FirstOrDefaultAsync(City => City.Id == Id);
        }

        public CityModel? FindByName(string name)
        {
            return _spappContextDb.Cities.FirstOrDefault(City => City.Name.Equals(name))!;
        }
        public async Task<CityModel> UpdateAsync(CityRequest request)
        {
           
            CityModel model = await FindCityAsync(request.Id);
            model.Name = request.Name;
            model.Region = request.Region;
            model.Latitude = request.Latitude;
            model.District = request.District;
            model.Population = request.Population;
            model.Area = request.Area;
            model.Longitude = request.Longitude;
            model.Updated_at = DateTime.Now;

            _spappContextDb.Cities.Update(model);
            await _spappContextDb.SaveChangesAsync();
            return model;
        }

        public async Task DeleteAsync(int Id)
        {
            CityModel model = await FindCityAsync(Id);
            _spappContextDb.Cities.Remove(model);
            await _spappContextDb.SaveChangesAsync();
        }

        public void BeforeSave(string Name)
        {
            CityModel? finded = FindByName(Name);

            if (finded is not null)
            {
                if (finded.Name.Equals(Name))
                {
                    throw new Exception($"La ville {Name} existe deja dans le systeme");
                }
            }

        }
    }
}
