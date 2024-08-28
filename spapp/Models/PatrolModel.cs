namespace spapp.Models
{
    public class PatrolModel
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public List<MunicipalityModel> Municipalities { get; set;}
        public List<NeighborhoodModel> Neighborhoods { get; set;}
        public List<NeighborhoodSectorModel> NeighborhoodSectors { get; set;}
        public VehicleModel Vehicle { get; set; }

    }
}
