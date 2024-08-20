using Microsoft.Extensions.Primitives;
using spapp.Models;

namespace spapp.Http.Response
{
    public class ComplainTypeResponse
    {

        public record ComplainTypeResource(int Id, string Name, string? Description, string Created_at, string? Updated_at, string Priority);


        public List<ComplainTypeResource> AsModelResponseList(List<ComplainTypeModel> types)
        {
            return types.Select(t => AsModelResponse(t)).ToList();
        }

        public ComplainTypeResource AsModelResponse(ComplainTypeModel type)
        {
            return new ComplainTypeResource(
                type.Id, type.Name, 
                type.Description, 
                type.Created_at.ToString("dd/MM/yyyy HH:mm"),
                type.Updated_at != null ? type.Updated_at.ToString("dd/MM/yyyy HH:mm") : "", 
                ""
               );
        }
    }
}
