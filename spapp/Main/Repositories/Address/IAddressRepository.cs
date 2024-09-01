using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.Repositories.Address
{
    public interface IAddressRepository
    {
        Task<AddressModel> CreateAsync(AddressRequest request);
    }
}
