using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record NeighborhoodSectorRequest(
        int Id,
        [Required(ErrorMessage = "Le nom é obligatoire")]
        string Name,
        [Required]
        int MunicipalityId,
        [Required(ErrorMessage = "Le quartier est obligatoire")]
        int? NeighborhoodId,
        bool IsRiskArea,
        double? Latitude,
        double? Longitude,
        string? Observation
    );
    
}
