
using spapp.Helpers;
using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.City
{
    public interface ICityRepository
    {
        Task<ServiceHttpResponseHandle<CityModel>?> CreateCityAsync(CityModel city, string url, HttpClient httpClient);
        Task<List<CityModel>?> GetAllCitiesAsync(HttpClient httpClient, string baseUrl);
        Task<CityModel> FindCityAsync(int Id);
        CityModel? FindByName(string name);
        Task<CityModel> UpdateAsync(CityRequest request);
        Task DeleteAsync(int Id);
        void BeforeSave(string Name);

    }
}
