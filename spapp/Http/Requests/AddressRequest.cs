using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record AddressRequest(
        string? StreetName,
        [Required(ErrorMessage = "La ville est obligatoire")]
        int CityId,
        [Required(ErrorMessage = "La commune est obligatoire")]
        int MunicipalityId,
        [Required(ErrorMessage = "Le quartier est obligatoire")]
        int NeighborhoodId,
        int? NeighborhoodSectorId = null,
        string? Complement = null,
        string? Indication = null,
        string? Origin = null,
        double? Latitude = null,
        double? Longitude = null
    );
}
