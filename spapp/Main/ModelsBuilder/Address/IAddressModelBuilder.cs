using spapp.Models;

namespace spapp.Main.ModelsBuilder.Address
{
    public interface IAddressModelBuilder
    {

        IAddressModelBuilder AddStreetName(string? streetName);
        IAddressModelBuilder AddHomeNumber(int? homeNumber);
        IAddressModelBuilder AddCityId(int CityId);
        IAddressModelBuilder AddMunicipalityId(int MunicipalityId);
        IAddressModelBuilder AddNeighborhoodId(int NeighbourhoodId);
        IAddressModelBuilder AddNeighborhoodSectorId(int? NeighbourhoodSectorId);
        IAddressModelBuilder AddComplement(string? Complement);
        IAddressModelBuilder AddLatitude(double? Latitude);
        IAddressModelBuilder AddLongitude(double? Longitude);
        IAddressModelBuilder AddIndication(string? Indication);
        IAddressModelBuilder AddOrigin(string Origin);
        AddressModel Build();
    }
}
