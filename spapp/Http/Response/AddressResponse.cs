using spapp.Models;

namespace spapp.Http.Response
{

    public record AddressResource(
        int Id,
        string? StreetName,
        string City,
        string Municipality,
        string Neighborhood,
        int CityId,
        int MunicipalityId,
        int NeighborhoodId,
        bool? IsRiskedArea = null,
        string? RiskObservation = null,
        string? NeighborhoodSector = null,
        int? NeighborhoodSectorId = null
    );
    public static class AddressResponse
    {

        public static List<AddressResource> AsModelResponseList(List<AddressModel> addresses)
        {
            return addresses.Select(add => AsModelResponse(add)).ToList();
        }

        public static AddressResource AsModelResponse(AddressModel address)
        {
            return new AddressResource(
                address.Id,
                address.StreetName,
                address.CityModel!.Name,
                address.MunicipalityModel!.Name,
                address.NeighborhoodModel!.Name,
                address.CityId,
                address.MunicipalityId,
                address.NeighborhoodId,
                address.NeighborhoodSectorModel?.IsRiskArea,
                address.NeighborhoodSectorModel?.Observation,
                address.NeighborhoodSectorModel?.Name,
                address.NeighborhoodSectorId
            );
        }
    }
}
