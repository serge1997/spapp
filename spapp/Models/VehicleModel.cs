using System.ComponentModel.DataAnnotations;

namespace spapp.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        //plaque d1imatriculation
        [Required(ErrorMessage = "Plaque d'imatriculation du vehicule est obligatoire")]
        public string LicensePlate { get; set; }
        [Required(ErrorMessage = "Le model du vehicule est obligatoire")]
        public string Model { get; set; }
        public int Year { get; set; }
        public long? KM { get; set; }
        [Required(ErrorMessage = "la marque du vehicule est obligatoire")]
        public int VehicleBrandId { get; set; }
        public string? Remark { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public virtual VehicleBrandModel VehicleBrandModel { get; set; }
        public PatrolModel? Patrol {  get; set; }
        
    }
}
