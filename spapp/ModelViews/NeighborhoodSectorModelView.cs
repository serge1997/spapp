using spapp.Models;
using System.ComponentModel.DataAnnotations;

namespace spapp.ModelViews
{
    public class NeighborhoodSectorModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "nom du secteur est obligatoire")]
        public string Name { get; set; }
        public string? Observation { get; set; }
        [Required(ErrorMessage = "la commune du secteur est obligatoire")]
        public int MunicipalityId { get; set; }
        [Required(ErrorMessage = "le quartier du secteur est obligatoire")]
        public int NeighborhoodId { get; set; }
        public bool IsRiskArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set; }

        public List<NeighborhoodModel> Neighborhoods { get; set; } = [];
        public List<MunicipalityModel> Municipalities { get; set; } = [];
    }
}
