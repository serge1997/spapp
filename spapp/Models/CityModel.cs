using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace spapp.Models
{
    public class CityModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom de la ville é obligatoire")]
        public string Name { get; set; }
        //public long? Area { get; set; }
        [Required(ErrorMessage = "Region de la ville é obligatoire")]
        public int Region_Id { get; set; }
        public string? District { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public long? Population { get; set; }
        public string Created_at { get; set; }
        public string? Updated_at { get; set; }

    }
}
