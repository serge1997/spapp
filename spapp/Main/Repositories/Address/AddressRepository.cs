using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
                .AddCityId(request.CityId)
                .AddMunicipalityId(request.MunicipalityId)
                .AddNeighborhoodId(request.NeighborhoodId)
                .AddNeighborhoodSectorId(request.NeighborhoodSectorId)
                .AddOrigin(request.Origin!)
                .AddCreatedAt()
                .Build();

            _spappContextDb.Addresses.Add(address);

            await _spappContextDb.SaveChangesAsync();

            return address;
        }

        public async Task<AddressModel?> FindByStreetNameAndCity(string streetName, int? CityId = null)
        {
            var Address = _spappContextDb.Addresses;
            if (CityId != null && !string.IsNullOrEmpty(streetName))
            {
                return await Address
                .FirstOrDefaultAsync(add => string.Equals(add.StreetName.ToLower(), streetName.ToLower()) && add.CityId == CityId);
            }

            return null;

        }

        public async Task<List<AddressModel>> FindByStreetName(string? streetName)
        {
            return await _spappContextDb.Addresses
                .Include(add => add.CityModel)
                .Include(add => add.MunicipalityModel)
                .Include(add => add.NeighborhoodModel)
                .Include(add => add.NeighborhoodSectorModel)
                .Where(add => add.StreetName!.Contains(streetName))
                .ToListAsync();
        }

        public async Task<AddressModel> FindOrCreate(AddressRequest request, int? agentAddressId = null)
        {
            AddressModel finded = await FindByStreetNameAndCity(request.StreetName!, request.CityId);

            AddressModel agentAddress = await FindByAgentAddressWithoutStreetName(agentAddressId);

            //update address if and address exists and streetname is null
            if (agentAddress is not null && AddressExists(agentAddress!, request, agentAddressId))
            {
                await UpdateAsync(agentAddress, request, agentAddressId);
                return agentAddress;
            }

            if (finded is null)
            {
                return await CreateAsync(request);
            }
            await UpdateAsync(finded, request, agentAddressId);
            return finded!;

        }

        public bool AddressExists(AddressModel finded, AddressRequest request, int? agentAddressId = null)
        {
           if (finded is not null)
           {
                if (agentAddressId is null)
                {
                    return finded.CityId == request.CityId
                        && request.MunicipalityId == request.MunicipalityId
                        && finded.NeighborhoodId == request.NeighborhoodId
                        && finded.NeighborhoodSectorId == request.NeighborhoodSectorId;
                }

                return finded.CityId == request.CityId
                       && request.MunicipalityId == request.MunicipalityId
                       && finded.NeighborhoodId == request.NeighborhoodId
                       && finded.NeighborhoodSectorId == request.NeighborhoodSectorId
                       && finded.Id == agentAddressId;
           }

            return false;

        }

        public async Task<AddressModel> FindByAgentAddressWithoutStreetName(int? AgentAdressId = null)
        {
            return await _spappContextDb.Addresses
                .FirstOrDefaultAsync(add => add.Id == AgentAdressId && string.IsNullOrEmpty(add.StreetName));
        }

        public async Task<AddressModel> UpdateAsync(AddressModel finded, AddressRequest request, int? agentAddressId = null)
        {
            
            
            finded.StreetName = request.StreetName;
            finded.NeighborhoodSectorId = request.NeighborhoodSectorId;
            finded.Updated_at = DateTime.Now;
            _spappContextDb.Addresses.Update(finded);
            await _spappContextDb.SaveChangesAsync();
            return finded;
        }
    }
}
