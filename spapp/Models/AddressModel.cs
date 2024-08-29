namespace spapp.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string? StreetName { get; set; } 
        public int City { get; set; }
        public int MunicipalityId { get; set; }
        public int NeighborhoodId { get; set; }
        public int? NeighborhoodSectorId { get; set; }
        public string? Complement {  get; set; }
        public string? Indication { get; set; }
        public string? Origin { get; set; }
        public DateTime Created_at {  get; set; }
        public DateTime? Updated_at { get; set; }

    }
}
