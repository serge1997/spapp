using spapp.Models;

namespace spapp.Main.ModelsBuilder.User
{
    public interface IUserModelBuilder
    {

        IUserModelBuilder AddPersonalData(
            string FullName,
            string? CNINumber = null,
            string? AtestationNumber = null
            );

        IUserModelBuilder AddAccountData(
            string? UserName = null,
            string? Password = null
            );

        IUserModelBuilder AddAddressData(
            int AddressId,
            string? HouseNumber = null,
            string? AddressComplement = null
          );

        IUserModelBuilder AddContactData(
            string PhoneNumber,
            string? Email = null
          );

        UserModel Build();
    }
}
