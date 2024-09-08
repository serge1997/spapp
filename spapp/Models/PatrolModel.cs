using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace spapp.Models
{
    public class PatrolModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public string? Observation { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public List<PatrolMunicipalityModel> PatrolMunicipalities { get; set;}
        public List<PatrolNeighborhoodModel> PatrolNeighborhoods { get; set;}
        public List<PatrolNeighborhoodSectorModel> PatrolNeighborhoodSectors { get; set;}
        public List<PatrolMemberModel> PatrolMembers { get; set;}
        public AgentModel Driver { get; set; }
    
        public VehicleModel Vehicle { get; set; }

    }
}
