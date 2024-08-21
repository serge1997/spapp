using spapp.Enums;

namespace spapp.Http.Requests
{
    public record ComplainTypeRequest(int Id, string Name, string? Description, PriorityEnum Priority, string? PenalCode, bool IsActive = true);
}
