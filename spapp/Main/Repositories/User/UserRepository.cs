using spapp.Http.Requests;
using spapp.Main.ModelsBuilder.User;
using spapp.Main.Repositories.Address;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.User
{
    public class UserRepository(
            SpappContextDb spappContext,
            IUserModelBuilder userModelBuilder,
            IAddressRepository addressRepository
        ) : IUserRepository
    {
        private readonly SpappContextDb _context = spappContext;
        private IUserModelBuilder _userModelBuilder = userModelBuilder;
        private readonly IAddressRepository _addressRepository = addressRepository;

        public async Task<UserModel> CreateAsync(UserRequest userRequest)
        {
            AddressModel address = await _addressRepository.FindOrCreate(userRequest.applicanAddress);
            UserModel user = _userModelBuilder
                .AddPersonalData(
                    userRequest.FullName,
                    userRequest.CNINumber,
                    userRequest.AtestationNumber
                )
                .AddAccountData(
                    userRequest.Username,
                    userRequest.Password
                )
                .AddContactData(
                    userRequest.PhoneNumber,
                    userRequest.Email
                )
                .AddAddressData(
                    address.Id,
                    userRequest.HouseNumber,
                    userRequest.AddressComplement
                )
                .Build();

            await _context.Users.AddAsync( user );
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
