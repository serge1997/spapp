using System.ComponentModel.DataAnnotations.Schema;

namespace spapp.Models
{
    public class VehicleBrandModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<VehicleModel> Vehicles { get; set; }

    }
}
