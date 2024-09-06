using spapp.Models;
using System.ComponentModel.DataAnnotations;
using spapp.Http.Requests;
using spapp.Enums;
using spapp.Http.Response;

namespace spapp.ModelViews
{
    public class AgentModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Le mot de passe obligatoire")]
        public string Password { get; set; }       
        public string? MatriculeNumber { get; set; }
        public string? CNINumber { get; set; }
        public string? AttestionNumber { get; set; }
        public string? BloodGroup { get; set; }
        [Required(ErrorMessage = "La division est obligatoire")]
        public int AgentRankId { get; set; }
        public string? AgentRank {  get; set; }
        [Required(ErrorMessage = "La grade est obligatoire")]
        public int AgentGroupId { get; set; }
        public string? AgentGroup {  get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public int? AddressId { get; set; }
        public string? Complement { get; set; }
        public string? Indication { get; set; }
        public int? HouseNumber { get; set; }

        //family info
        public int? ChilddrenQuantity { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public List<AgentRankModel> AgentRanks { get; set; } = [];
        public List<CityModel> Citys { get; set; } = [];
        public AddressRequest? AddressRequest { get; set; }
        public AddressModel? Address {  get; set; }
    }
}
