using spapp.Models;

namespace spapp.Main.ModelsBuilder.Address
{
    public interface IAddressModelBuilder
    {

        AddressModelBuilder AddStreetName(string streetName);
        AddressModelBuilder AddCityId(int CityId);
        AddressModelBuilder AddMunicipalityId(int MunicipalityId);
        AddressModelBuilder AddNeighborhoodId(int NeighbourhoodId);
        AddressModelBuilder AddNeighborhoodSectorId(int? NeighbourhoodSectorId);
        AddressModelBuilder AddComplement(string? Complement);
        AddressModelBuilder AddLatitude(double? Latitude);
        AddressModelBuilder AddLongitude(double? Longitude);
        AddressModelBuilder AddIndication(string? Indication);
        AddressModelBuilder AddOrigin(string Origin);
        AddressModel Build();
    }
}
