using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using spapp.Enums;

namespace spapp.Models
{
    public class AgentModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string MatriculeNumber { get; set; }
        public string? CNINumber {  get; set; }
        public string? AttestionNumber { get; set; }
        public string? BloodGroup { get; set; }
        public int AgentRankId { get; set; }
        public int AgentGroupId { get; set; }
        public string? Contact {  get; set; }
        public string? Email {  get; set; }
        public int AddressId { get; set; }
        public DateTime Created_at {  get; set; }
        public DateTime? Updated_at {  set; get; }

        //family info
        public int? ChilddrenQuantity {  get; set; }
        public MaritalStatusEnum MaritalStatus {  get; set; }
        public AgentGroupModel AgentGroup { get; set; }
        public AgentRankModel AgentRank { get; set; }
        public AddressModel Address { get; set; }
        
        
    }
}
