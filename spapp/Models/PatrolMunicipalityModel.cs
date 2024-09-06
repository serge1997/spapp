namespace spapp.Models
{
    public class PatrolMunicipalityModel
    {

        public int Id { get; set; }
        public int PatrolId { get; set; }
        public int MunicipalityId { get; set; }
        public DateTime Created_at { get; set; }
        public PatrolModel Patrol { get; set; }
        public MunicipalityModel Municipality { get; set; }
    }
}
