using spapp.Models;

namespace spapp.Http.Response
{
    public class ComplainTypeCategoryResponse
    {
       
        public List<ComplainTypeCategoryModel> ToResponse(List<ComplainTypeCategoryModel> categories)
        {
            return categories.Select(e => ToEntity(e.Id, e.Name, e.Description, e.IsActive, e.Created_at)).ToList();
        }

        public ComplainTypeCategoryModel ToEntity(int Id, string Name, string? Description, bool IsActive, DateTime Created_at)
        {
            ComplainTypeCategoryModel type = new()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                IsActive = IsActive,
                Created_at = Created_at
            };

            return type;
        }
    }
}
