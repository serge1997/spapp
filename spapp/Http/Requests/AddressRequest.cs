using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record AddressRequest(
        int Id,
        string? StreetName,
        //public int? HouseNumber { get; set; }
        [Required(ErrorMessage = "La ville est obligatoire")]
        int CityId,
        [Required(ErrorMessage = "La commune est obligatoire")]
        int MunicipalityId,
        [Required(ErrorMessage = "Le quartier est obligatoire")]
        int NeighborhoodId,
        int? NeighborhoodSectorId,
        string? Complement,
        string? Indication,
        string? Origin,
        double? Latitude,
        double? Longitude
    );
}
