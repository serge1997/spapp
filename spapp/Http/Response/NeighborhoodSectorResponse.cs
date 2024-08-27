using spapp.Models;

namespace spapp.Http.Response
{

    public record NeighborhoodSectorResource(
        int Id,
        string Name,
        string Municipality,
        int MunicipalityId,
        string Neighborhood,
        int NeighborhoodId,
        string City,
        string IsRiskArea,
        string Createt_at,
        string? Observation
 
    );
    public static class NeighborhoodSectorResponse
    {

        public static List<NeighborhoodSectorResource> AsModelListResponse(List<NeighborhoodSectorModel> entities)
        {
            return entities.Select(sector => AsModelResponse(sector)).ToList();
        }

        public static NeighborhoodSectorResource AsModelResponse(NeighborhoodSectorModel model )
        {
            return new NeighborhoodSectorResource(
                    model.Id,
                    model.Name,
                    model.Municipality.Name,
                    model.MunicipalityId,
                    model.Neighborhood.Name,
                    model.NeighborhoodId,
                    model.Municipality.City.Name,
                    model.IsRiskArea == true ? "Zone á risque" : "Pas de risque",
                    model.Created_at.ToString("dd/mm/yyyy"),
                    model.Observation
                );
        }
    }
}
