using Microsoft.Extensions.Primitives;
using spapp.Models;

namespace spapp.Http.Response
{
    public record NeighborhoodResource(
        int Id,
        string Name,
        string City,
        int CityId,
        string Municipality,
        int MunicipalityId,
        string Created_at,
        double? Latitude,
        double? Longitude

    );

    public static class NeighborhoodResponse
    {


        public static List<NeighborhoodResource> AsModelListResponse(List<NeighborhoodModel> entities) 
        { 
            return entities.Select(nei => AsModelResponse(nei)).ToList();
        }

        public static NeighborhoodResource AsModelResponse(NeighborhoodModel model)
        {
            return new NeighborhoodResource(
                model.Id,
                model.Name,
                model.City.Name,
                model.CityId,
                model.Municipality.Name,
                model.MunicipalityId,
                model.Created_at.ToString("dd/MM/yyyy HH:mm"),
                model.Latitude,
                model.Longitude
             );
        }

    }



}
