using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record NeighborhoodSectorRequest(
        int Id,
        [Required]
        string Name,
        [Required]
        int? MunicipalityId,
        [Required]
        int? NeighborhoodId,
        bool IsRiskArea,
        double? Latitude,
        double? Longitude,
        string? Observation
    );
    
}
