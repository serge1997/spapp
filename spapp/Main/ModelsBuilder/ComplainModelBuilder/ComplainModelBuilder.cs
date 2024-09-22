using spapp.Http.Requests;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.ComplainModelBuilder
{
    public class ComplainModelBuilder : IComplainModelBuilder
    {

        public ComplaintModel _complain;
        public ComplainModelBuilder()
        {
            this._complain = new ComplaintModel();
        }

        public IComplainModelBuilder AddApplicant(UserRequest userRequest)
        {
            this._complain.Applicant!.Username = userRequest.Username;
            this._complain.Applicant.PhoneNumber = userRequest.PhoneNumber;
            this._complain.Applicant.CNINumber = userRequest.CNINumber;
            this._complain.Applicant.AtestationNumber = userRequest.AtestationNumber;
            this._complain.Applicant.Email = userRequest.Email;
            this._complain.Applicant.AddressId = userRequest.AddressId;
            this._complain.Applicant.HouseNumber = userRequest.HouseNumber;
            this._complain.Applicant.AddressComplement = userRequest.AddressComplement;
            this._complain.Applicant.Password = userRequest.Password;
            this._complain.Applicant.Origem = Enums.OriginEnum.WebAgentApp;
            return this;
        }
    }
}
