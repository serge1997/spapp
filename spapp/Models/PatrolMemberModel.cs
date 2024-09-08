namespace spapp.Models
{
    public class PatrolMemberModel
    {
        public int Id { get; set; }
        public int PatrolId { get; set; }
        public int AgentId { get; set; }
        public DateTime Created_at { get; set; }
        public AgentModel Agent { get; set; }
        public PatrolModel Patrol { get; set; }
    }
}
