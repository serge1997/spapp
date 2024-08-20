using System.ComponentModel.DataAnnotations;

namespace spapp.Http.Requests
{
    public record ComplainTypeCategoryRequest(
        int Id,
        [Required(ErrorMessage = "Nom é obligatoire")]
        string Name, 
        string? Description, 
        bool IsActive = true
    );
}
