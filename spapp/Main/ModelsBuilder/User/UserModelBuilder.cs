using spapp.Models;

namespace spapp.Main.ModelsBuilder.User
{
    public class UserModelBuilder : IUserModelBuilder
    {
        private UserModel _user;

        public UserModelBuilder()
        {
            this._user = new UserModel();
        }


        public IUserModelBuilder AddPersonalData(
           string FullName,
           string? CNINumber = null,
           string? AtestationNumber = null)
        {
            this._user.FullName = FullName;
            this._user.CNINumber = CNINumber;
            this._user.AtestationNumber = AtestationNumber;
            return this;
        }

        public IUserModelBuilder AddAccountData(
            string? UserName = null,
            string? Password = null)
        {
            this._user.Username = UserName;
            this._user.Password = Password;
            return this;
        }

        public IUserModelBuilder AddAddressData(
            int AddressId,
            string? HouseNumber = null,
            string? AddressComplement = null)
        {
            this._user.AddressId = AddressId;
            this._user.HouseNumber = HouseNumber;
            this._user.AddressComplement = AddressComplement;
            return this;
        }

        public IUserModelBuilder AddContactData(
            string PhoneNumber,
            string? Email = null)
        {
            this._user.PhoneNumber = PhoneNumber;
            this._user.Email = Email;

            return this;
        }

        public UserModel Build()
        {
            return this._user;
        }
    }
}
