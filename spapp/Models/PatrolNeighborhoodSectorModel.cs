namespace spapp.Models
{
    public class PatrolNeighborhoodSectorModel
    {

        public int Id { get; set; }
        public int PatrolId { get; set; }
        public int NeighbordhoodSectorId { get; set; }
        public DateTime Created_at { get; set; }
    }
}
