using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Models;

namespace spapp.ModelViews
{
    public class NeighborhoodModelView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public long? Population { get; set; }
        public int MunicipalityId { get; set; }
        public int CityId { get; set; }
        public List<MunicipalityModel> Municipalities { get; set; } = [];
        public List<CityModel> Cities { get; set; } = [];


        public async Task SetMunicipalities(IMunicipalityRepository municipalityRepository)
        {
            List<MunicipalityModel> muns = await municipalityRepository.GetAllMunicipalityAsync();

            foreach(MunicipalityModel municipality in muns)
            {
                this.Municipalities.Add(municipality);
            }
        }

        public async Task SetCities(ICityRepository cityRepository, HttpClient httpClient, string baseUrl)
        {
            List<CityModel>? cities = await cityRepository.GetAllCitiesAsync(httpClient, baseUrl);

            foreach(CityModel city in cities!)
            {
                this.Cities.Add(city);
            }
        }
    }
}
