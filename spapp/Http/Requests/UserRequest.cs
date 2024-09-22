namespace spapp.Http.Requests
{
    public record UserRequest
    (
        int Id,
        string FullName,
        string PhoneNumber,
        AddressRequest applicanAddress,
        string? ApplicantAddressStreetName,
        string? CNINumber,
        string? AtestationNumber,
        string? Email,
        string? Username,
        string? Password,
        int AddressId,
        string? HouseNumber,
        string? AddressComplement,
        int Origem);
}
