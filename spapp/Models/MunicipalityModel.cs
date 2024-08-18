using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spapp.Models
{
    //communes
    public class MunicipalityModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public long? Population { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public CityModel City { get; set; }
        public virtual List<NeighborhoodModel>? Neighborhoods { get; set; }
    }
}
