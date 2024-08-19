namespace spapp.Http.Requests
{
    public record ComplainTypeRequest(int Id, string Name, string? Description, bool IsActive = true);
}
