using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace spapp.Models
{
    //GSPM, Police national, Gendarmerie, Garde municipal, marine
    public class AgentGroupModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string? Description { get; set; }
    }
}
