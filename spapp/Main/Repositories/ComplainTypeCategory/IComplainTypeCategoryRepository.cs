using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Models;

namespace spapp.Main.Repositories.ComplainTypeCategory
{
    public interface IComplainTypeCategoryRepository
    {

        Task<ComplainTypeCategoryModel> CreateAsync(ComplainTypeCategoryRequest model);

        Task<List<ComplainTypeCategoryResource>> GetAllAsync();

        Task<ComplainTypeCategoryResource> FindAsync(int Id);
        Task<ComplainTypeCategoryResource> UpdateAsync(ComplainTypeCategoryRequest request);

        Task<ComplainTypeCategoryResource> DeleteAsync(int Id);

    }
}
