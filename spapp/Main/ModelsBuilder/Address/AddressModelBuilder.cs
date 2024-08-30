using spapp.Models;

namespace spapp.Main.ModelsBuilder.Address
{
    public class AddressModelBuilder : IAddressModelBuilder
    {
        private AddressModel _adress = new();

        public AddressModelBuilder AddStreetName(string? streetName)
        {
            _adress.StreetName = streetName;
            return this;
        }

        public AddressModelBuilder AddCityId(int CityId)
        {
            _adress.CityId = CityId;
            return this;
        }

        public AddressModelBuilder AddMunicipalityId(int MunicipalityId)
        {
            this._adress.MunicipalityId = MunicipalityId;
            return this;
        }

        public AddressModelBuilder AddNeighborhoodId(int NeighborhoodId)
        {
            this._adress.NeighborhoodId = NeighborhoodId;
            return this;
        }

        public AddressModelBuilder AddNeighborhoodSectorId(int? NeighboorhoodSectorId)
        {
            this._adress.NeighborhoodSectorId = NeighboorhoodSectorId;
            return this;
        }

        public AddressModelBuilder AddComplement(string? Complement)
        {
            this._adress.Complement = Complement;
            return this;
        }

        public AddressModelBuilder AddLatitude(double? Latitude)
        {
            this._adress.Latitude = Latitude;
            return this;
        }

        public AddressModelBuilder AddLongitude(double? Longitude)
        {
            this._adress.Longitude = Longitude;
            return this;
        }

        public AddressModelBuilder AddIndication(string? Indication)
        {
            this._adress.Indication = Indication;
            return this;
        }
        public AddressModelBuilder AddOrigin(string Origin)
        {
            this._adress.Origin = Origin;
            return this;
        }
        public AddressModel Build()
        {
            return _adress;
        }
    }
}
