using spapp.Models;

namespace spapp.ModelViews
{
    public class PatrolModelView
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int VehicleId { get; set; }
        public int[]? MembersId { get; set; }
        public int[]? MunicipalitiesId { get; set; }
        public int[]? NeighbordhoodsId { get; set; }
        public int[]? NeighbordhoodSectorsId { get; set; }
        public List<MunicipalityModel> Municipalities { get; set; } = [];
        public List<NeighborhoodModel> Neighborhoods { get; set; } = [];
        public List<NeighborhoodSectorModel> NeighborhoodSectors { get; set; } = [];
        public List<VehicleModel> Vehicles { get; set; }
        public List<AgentModel> Agents { get; set; }
    }
}
