using spapp.Main.Repositories.City;
using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Municipality
{
    public interface IMunicipalityRepository
    {
        Task<MunicipalityModel> CreateAsync(MunicipalityModelView model);
        Task<List<MunicipalityModel>?> GetAllMunicipalityAsync();
        Task<MunicipalityModel> FindAsync(int Id);
        MunicipalityModel? FindByNameAndCity(string Name, int City);
        Task<MunicipalityModel> UpdateAsync(MunicipalityModel model);
        Task<MunicipalityModel> DeleteAsync(int Id);
        Task<List<MunicipalityModel>> GetMunicipalitiesByCityAsync(int Id);
        Task<MunicipalityModelView> SetMunicipalityModelView(ICityRepository cityRepository);
        void BeforeSave(string Name, int City);
    }
}
