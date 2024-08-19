using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace spapp.Models
{
    public class ComplainTypeCategoryModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}
        public string Name {get; set;}
        public string? Description {get; set;}
        public bool IsActive { get; set; } = true;
        public DateTime Created_at {get; set;}
        public DateTime? Updated_at {get; set;}
        //public virtual List<ComplainTypeModel> ComplainTypes { get; set;}
    }
}