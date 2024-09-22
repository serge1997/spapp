using spapp.Models;
using System.ComponentModel.DataAnnotations;
using spapp.Http.FormValidation;

namespace spapp.Http.Requests
{
    public record ComplainRequest
    {
        [RequiredIf("IsAnonyme", ErrorMessage = "Nome do requerente é obrigatório se não for anônimo.")]
        public string? ApplicantFullname;
        public string? ApplicantPhoneNumber;
        public string? ApplicantAddressStreetName;
        public string? ApplicantCNINumber;
        public string? ApplicantAtestationNumber;
        public string? ApplicantEmail;
        public string? ApplicantUsername;
        public string? ApplicantPassword;
        public string? ApplicantHouseNumber;
        public string? ApplicantAddressComplement;
        public int ApplicantOrigem;
        public int ApplicantAddressCityId;
        public int ApplicantAddressMunicipalityId;
        public int ApplicantAddressNeighborhood;
        public int ApplicantAddressNeighborhoodSector;
        public bool IsAnonyme = false;
    }
    
}
