namespace spapp.Http.Requests
{
    public record ComplainTypeCategoryRequest(int Id, string Name, string? Description, bool IsActive = true);
}
