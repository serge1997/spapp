using spapp.Models;

namespace spapp.ModelViews
{
    public class AgentModelView
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MatriculeNumber { get; set; }
        public string? CNINumber { get; set; }
        public string AttestionNumber { get; set; }
        public string? BloodGroup { get; set; }
        public int AgentRankId { get; set; }
        public int AgentGroupId { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public int AddressId { get; set; }

        //family info
        public int? ChilddrenQuantity { get; set; }
        public string? MaritalStatus { get; set; }
        public List<AgentRankModel> AgentRanks { get; set; } = [];
        public List<CityModel> Citys { get; set; } = [];
        public AddressModel Address { get; set; }
    }
}
