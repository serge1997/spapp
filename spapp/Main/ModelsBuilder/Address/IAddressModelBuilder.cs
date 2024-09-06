using spapp.Models;

namespace spapp.Main.ModelsBuilder.Address
{
    public interface IAddressModelBuilder
    {

        IAddressModelBuilder AddStreetName(string? streetName);
        IAddressModelBuilder AddCityId(int CityId);
        IAddressModelBuilder AddMunicipalityId(int MunicipalityId);
        IAddressModelBuilder AddNeighborhoodId(int NeighbourhoodId);
        IAddressModelBuilder AddNeighborhoodSectorId(int? NeighbourhoodSectorId);
        IAddressModelBuilder AddOrigin(string Origin);
        IAddressModelBuilder AddCreatedAt();
        AddressModel Build();
    }
}
