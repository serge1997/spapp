using spapp.Models;

namespace spapp.Http.Response
{

    public record MunicipalityResource(
        int Id,
        string Name,
        string City,
        int CityId,
        string Created_at,
        double? Latitude,
        double? Longitude,
        long? Population
    );

    public static class MunicipalityResponse
    {

        public static List<MunicipalityResource>? AsModelListResponse(List<MunicipalityModel> entities)
        {
            return entities.Select(mun => AsModelResponse(mun)).ToList();
        }
        public static MunicipalityResource AsModelResponse(MunicipalityModel entity)
        {
            return new MunicipalityResource(
                entity.Id,
                entity.Name,
                entity.City.Name,
                entity.CityId,
                entity.Created_at.ToString("dd/mm/yyyy HH:mm"),
                entity.Latitude,
                entity.Longitude,
                entity.Population
             );
        }
    }
}
