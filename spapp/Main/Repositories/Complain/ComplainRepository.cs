using spapp.Http.Requests;
using spapp.Models;
using spapp.SpappContext;
using spapp.Main.Repositories.User;
using spapp.Main.Repositories.Address;

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
            if (complainRequest.applicantRequest is not null)
            {
                await _userRepository.CreateAsync(complainRequest.applicantRequest);
            }
         
            return new ComplaintModel();
        }
    }
}
