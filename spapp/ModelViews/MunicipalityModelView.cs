using spapp.Main.Repositories.City;
using spapp.Models;
using System.ComponentModel.DataAnnotations;

namespace spapp.ModelViews
{
    public class MunicipalityModelView
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nom de la commune é obligatoire")]
        public string Name { get; set; }
        [Required(ErrorMessage = "la ville é obligatoire")]
        public int CityId { get; set; }
        public float? Latitude { get; set; }
        public float? Longitude { get; set; }
        public long? Population { get; set; }
        public List<CityModel> Cities { get; set; } = new List<CityModel>();

    }
}
