using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.Address
{
    public interface IAddressRepository
    {
        Task<AddressModel> CreateAsync(AddressRequest request);
        Task<AddressModel> FindByStreetNameAndCity(string streetName, int? CityId = null);
        Task<AddressModel> FindOrCreate(AddressRequest request, int? agentAddressId = null);
        bool AddressExists(AddressModel finded, AddressRequest request, int? agentAddressId = null);
        Task<AddressModel> UpdateAsync(AddressModel finded, AddressRequest request, int? agentAddressId = null);
        Task<AddressModel> FindByAgentAddressWithoutStreetName(int? AgentAdressId = null);
    }
}
