using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Models;

namespace spapp.Main.Repositories.ComplainTypeCategory
{
    public interface IComplainTypeCategoryRepository
    {

        Task<ComplainTypeCategoryModel> CreateAsync(ComplainTypeCategoryRequest model);

        Task<List<ComplainTypeCategoryModel>> GetAllAsync();

        Task<ComplainTypeCategoryModel> FindAsync(int Id);
        Task<ComplainTypeCategoryModel> UpdateAsync(ComplainTypeCategoryRequest request);

        Task<ComplainTypeCategoryModel> DeleteAsync(int Id);

    }
}
