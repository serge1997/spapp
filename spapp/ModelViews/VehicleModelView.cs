using spapp.Main.Repositories.VehicleBrand;
using spapp.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace spapp.ModelViews
{
    public class VehicleModelView
    {
        public int Id { get; set; }
        //plaque d1imatriculation
        [Required(ErrorMessage = "la marque du vehicule est obligatoire")]
        public string LicensePlate { get; set; }
       
        [Required(ErrorMessage = "Le model du vehicule est obligatoire")]
        public string Model { get; set; }
        public int Year { get; set; }
        public long? KM { get; set; }
        [Required(ErrorMessage = "la marque du vehicule est obligatoire")]
        public int VehicleBrandId { get; set; }
        public string? Remark { get; set; }
        public List<VehicleBrandModel> VehicleBrands { get; set; } = [];


        public async Task SetVehicleBrands(IVehicleBrandRepository repository)
        {
            List<VehicleBrandModel> brands = await repository.GetAllAsync();

            foreach (VehicleBrandModel brand in brands)
            {
                this.VehicleBrands.Add(brand);
            }
        }
    }
}
