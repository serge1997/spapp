using Microsoft.Extensions.Primitives;
using spapp.Helpers;
using spapp.Models;

namespace spapp.Http.Response
{
    public record ComplainTypeResource(
        int Id, 
        string Name, 
        string? Description,
        string Category,
        string IsActive, 
        string? PenalCode, 
        string Priority,
        string Created_at
        );

    public class ComplainTypeResponse
    {
        public List<ComplainTypeResource> AsModelResponseList(List<ComplainTypeModel> types)
        {
            return types.Select(t => AsModelResponse(t)).ToList();
        }

        public ComplainTypeResource AsModelResponse(ComplainTypeModel type)
        {
            return new ComplainTypeResource(
                type.Id, 
                type.Name,
                type.Description,
                type.ComplainTypeCategory.Name,                          
                type.IsActive == true ? "Active" : "Desactivé",
                type.PenalCode, 
                type.Priority.PriorityFullName(),
                 type.Created_at.ToString("dd/MM/yyyy HH:mm")
               );
        }
    }
}
