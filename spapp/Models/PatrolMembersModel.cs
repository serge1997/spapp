using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace spapp.Models
{
    public class PatrolMembersModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }
        public int AgentId { get; set; }
        public int PatrolId { get; set; }
        public DateTime Created_at {  get; set; }
       
    }
}
