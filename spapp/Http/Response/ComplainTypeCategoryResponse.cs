using spapp.Models;

namespace spapp.Http.Response
{
    public record ComplainTypeCategoryResource(int Id, string Name, string? Description, string IsActive, string Created_at);
    public class ComplainTypeCategoryResponse
    {
       
        public List<ComplainTypeCategoryResource> AsModelListResponse(List<ComplainTypeCategoryModel> categories)
        {
            return categories.Select(complainTypeCategory => AsModelResponse(complainTypeCategory)).ToList();
        }

        public ComplainTypeCategoryResource AsModelResponse(ComplainTypeCategoryModel type)
        {


            return new ComplainTypeCategoryResource(
                type.Id, 
                type.Name, 
                type.Description == null ? "Non informé" : type.Description, 
                type.IsActive == true ? "Active" : "Desctivé", 
                type.Created_at.ToString("dd/MM/yyyy HH:mm"));
        }
    }
}
