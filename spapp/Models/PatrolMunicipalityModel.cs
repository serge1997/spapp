namespace spapp.Models
{
    public class PatrolMunicipalityModel
    {

        public int Id { get; set; }
        public int PatrolId { get; set; }
        public int MunicpalityId { get; set; }
        public DateTime Created_at { get; set; }
    }
}
