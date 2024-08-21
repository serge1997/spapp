using spapp.Enums;

namespace spapp.Models
{
    public class ComplainTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int ComplaintTypeCategoryId { get; set; }
        public bool IsActive { get; set; } = true;
        public PriorityEnum Priority { get; set; }
        public string? PenalCode { get; set; }
        public ComplainTypeCategoryModel ComplainTypeCategory {get; set;}
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }



        
    }
}
