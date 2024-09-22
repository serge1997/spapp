using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;
using spapp.Main.Repositories.User;
using spapp.Main.Repositories.Address;
using spapp.Enums;

namespace spapp.Main.Repositories.Complain
{
    public class ComplainRepository(
        SpappContextDb spappContextDb,
        IUserRepository userRepository, 
        IAddressRepository addressRepository ) : IComplainRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IAddressRepository _addressRepository = addressRepository;


        public async Task<ComplaintModel> CreateWebAgentComplain(ComplainRequest complainRequest)
        {
            await _userRepository.CreateAsync(
                       new UserRequest(
                           complainRequest.ApplicantFullname!,
                           complainRequest.ApplicantPhoneNumber!,
                           complainRequest.ApplicantCNINumber,
                           complainRequest.ApplicantAtestationNumber,
                           complainRequest.ApplicantEmail,
                           complainRequest.ApplicantUsername,
                           complainRequest.ApplicantPassword,
                           complainRequest.ApplicantHouseNumber,
                           complainRequest.ApplicantAddressComplement,
                           (int)OriginEnum.WebAgentApp,
                           complainRequest.ApplicantAddressStreetName!,
                           complainRequest.ApplicantAddressCityId,
                           complainRequest.ApplicantAddressMunicipalityId,
                           complainRequest.ApplicantAddressNeighborhood,
                           complainRequest.ApplicantAddressNeighborhoodSector
                       )
            );
            return new ComplaintModel();
        }
    }
}
