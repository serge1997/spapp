using System.Runtime.CompilerServices;

namespace spapp.Http.Requests
{
    public record UserRequest
    (
        string FullName,
        string PhoneNumber,
        string? CNINumber,
        string? AtestationNumber,
        string? Email,
        string? Username,
        string? Password,
        string? HouseNumber,
        string? AddressComplement,
        int Origem,
        string AddressStreetName,
        int AddressCityId,
        int MunicipalityId,
        int Neighborhood,
        int? NeighborhoodSector,
        int? Id = null);

   
}
