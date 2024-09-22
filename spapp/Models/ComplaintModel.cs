using spapp.Enums;

namespace spapp.Models
{
    public class ComplaintModel
    {
        public int Id { get; set; }
        public int ComplaintTypeId { get; set; }
        public int? AgentId { get; set; }
        public string Description { get; set; }
        public int OriginId { get; set; }
        public string? VictimFullName { get; set; }
        public ComplaintStatusEnum ComplaintStatus { get; set; }
        public int? Applicant_id {  get; set; } 
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public virtual ComplainTypeModel ComplaintType { get; set; }
        public virtual ComplaintOriginModel ComplaintOriginModel { get; set; }
        public virtual AgentModel? Agent { get; set; }
        public virtual List<PatrolModel>? Patrols { get; set; }
        public UserModel? Applicant { get; set; } = new();
    }
}
