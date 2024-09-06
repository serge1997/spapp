namespace spapp.Models
{
    public class PatrolModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public string? Observation { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public List<MunicipalityModel> Municipalities { get; set;}
        public List<NeighborhoodModel> Neighborhoods { get; set;}
        public List<NeighborhoodSectorModel> NeighborhoodSectors { get; set;}
        public AgentModel Driver { get; set; }
        public List<AgentModel>? Members { get; set; }
        public VehicleModel Vehicle { get; set; }

    }
}
