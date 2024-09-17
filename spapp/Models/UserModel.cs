using spapp.Enums;

namespace spapp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string? CNINumber { get; set; }
        public string? AtestationNumber { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public int AddressId { get; set; }
        public string? HouseNumber { get; set; }
        public string? AddressComplement { get; set; }
        public OriginEnum Origem {  get; set; }
        public string? AccountActivationKey { get; set; }
        public bool IsActivatedAccount { get; set; } = false;
        public bool IsAccessBlocked { get; set; } = true;
        public bool IsWanted { get; set; } = false;
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public AddressModel Address { get; set; }



        public bool HasAccessBlocked()
        {
            return this.IsAccessBlocked == true;
        }

        public bool HasAccountActivationKey()
        {
            return !string.IsNullOrEmpty(this.AccountActivationKey);
        }

        public bool HasAccountActivated()
        {
            return this.IsActivatedAccount == true;
        }

        public bool HeIsWantedPerson()
        {
            return this.IsWanted == true;
        }

    }
}
