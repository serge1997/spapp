using spapp.Models;

namespace spapp.Main.ModelsBuilder.Address
{
    public class AddressModelBuilder : IAddressModelBuilder
    {
        private AddressModel _adress = new();

        public IAddressModelBuilder AddStreetName(string? streetName)
        {
            _adress.StreetName = streetName;
            return this;
        }

        

        public IAddressModelBuilder AddCityId(int CityId)
        {
            _adress.CityId = CityId;
            return this;
        }

        public IAddressModelBuilder AddMunicipalityId(int MunicipalityId)
        {
            this._adress.MunicipalityId = MunicipalityId;
            return this;
        }

        public IAddressModelBuilder AddNeighborhoodId(int NeighborhoodId)
        {
            this._adress.NeighborhoodId = NeighborhoodId;
            return this;
        }

        public IAddressModelBuilder AddNeighborhoodSectorId(int? NeighboorhoodSectorId)
        {
            this._adress.NeighborhoodSectorId = NeighboorhoodSectorId;
            return this;
        }


        public IAddressModelBuilder AddOrigin(string Origin)
        {
            this._adress.Origin = Origin;
            return this;
        }

        public IAddressModelBuilder AddCreatedAt()
        {
            this._adress.Created_at = DateTime.Now;
            return this;
        }
        public AddressModel Build()
        {
            return _adress;
        }
    }
}
