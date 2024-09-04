using Microsoft.EntityFrameworkCore;
using spapp.Http.Requests;
using spapp.Main.ModelsBuilder.Address;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;
using System.Net;

namespace spapp.Main.Repositories.Address
{
    public class AddressRepository(
        SpappContextDb spappContextDb,
        IAddressModelBuilder addressModelBuilder
    ) : IAddressRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly IAddressModelBuilder _addressModelBuilder = addressModelBuilder;

        public async Task<AddressModel> CreateAsync(AddressRequest request)
        {
            AddressModel address = _addressModelBuilder
                .AddStreetName(request.StreetName!)
                 //.AddHomeNumber(agentModelView.Address.HouseNumber!)
                .AddCityId(request.CityId)
                .AddMunicipalityId(request.MunicipalityId)
                .AddNeighborhoodId(request.NeighborhoodId)
                .AddNeighborhoodSectorId(request.NeighborhoodSectorId)
                .AddLatitude(request.Latitude)
                .AddLongitude(request.Longitude)
                .AddIndication(request.Indication)
                .AddOrigin(request.Origin!)
                .AddComplement(request.Complement)
                .AddCreatedAt()
                .Build();

            _spappContextDb.Addresses.Add(address);
            //_spappContextDb.Agents.Add(agent);

            await _spappContextDb.SaveChangesAsync();

            return address;
        }

        public async Task<AddressModel> FindByStreetNameAndCity(string streetName, int? CityId = null)
        {
            var Address = _spappContextDb.Addresses;
            if (CityId != null)
            {
                return await Address
                .FirstOrDefaultAsync(add => string.Equals(add.StreetName.ToLower(), streetName.ToLower()) && add.CityId == CityId);
            }

            return await Address
                .FirstOrDefaultAsync(add => string.Equals(add.StreetName.ToLower(), streetName.ToLower()));

        }

        public async Task<AddressModel> FindOrCreate(AddressRequest request)
        {
            AddressModel finded = await FindByStreetNameAndCity(request.StreetName!, request.CityId);

            if (finded is null)
            {
                await CreateAsync(request);
            }

            return finded!;

        }
    }
}
