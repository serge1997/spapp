namespace spapp.Models
{
    public class ComplaintOriginModel
    {
        public int Id { get; set; }
        //must be an abreviation CPAPP
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
