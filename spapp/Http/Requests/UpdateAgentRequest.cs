using spapp.Enums;
using spapp.Models;
using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record UpdateAgentRequest(
        int Id,
        string FullName,
        int AgentRankId,
        MaritalStatusEnum MaritalStatus,
        string StreetName,
        [Required(ErrorMessage = "La ville est obligatoire")]
        int CityId,
        [Required(ErrorMessage = "La commune est obligatoire")]
        int MunicipalityId,
        [Required(ErrorMessage = "Le quartier est obligatoire")]
        int NeighborhoodId,
        string? Email = null,
        string? CNINumber = null,
        string? AttestionNumber = null,
        string? BloodGroup = null,
        int? ChilddrenQuantity = null,
        string? Contact = null,
        int? NeighborhoodSectorId = null,
        string? Complement = null,
        string? Indication = null,
        string? Origin = null,
        double? Latitude = null,
        double? Longitude = null

    );
    
}
