namespace spapp.Models
{
    public class NeighborhoodSectorModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string? Observation {  get; set; }
        public int MunicipalityId { get; set; }
        public int NeighborhoodId { get; set; }
        public bool IsRiskArea { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime? Updated_at { get; set;}

        public NeighborhoodModel Neighborhood { get; set; }
        public MunicipalityModel Municipality { get; set; }
        public List<PatrolNeighborhoodSectorModel> PatrolNeighborhoods { get; set; }
    }
}
