namespace spapp.Models
{
    public class PatrolNeighborhoodModel
    {
        public int Id { get; set; }
        public int PatrolId { get; set; }
        public int NeighbordhoodId { get; set; }
        public DateTime Created_at { get; set; }
    }
}
