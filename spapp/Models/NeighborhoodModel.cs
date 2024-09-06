using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spapp.Models
{
    public class NeighborhoodModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public long? Population { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public int MunicipalityId { get; set; }
        public int CityId { get; set; }
        public MunicipalityModel Municipality { get; set; }
        public CityModel City { get; set; }
        public List<NeighborhoodSectorModel> NeighborhoodSectors { get; set; }
        public List<PatrolNeighborhoodModel> PatrolNeighborhoods { get; set; }
    }
}
