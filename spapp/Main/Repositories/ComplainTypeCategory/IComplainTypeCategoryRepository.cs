using spapp.Models;

namespace spapp.Main.Repositories.ComplainTypeCategory
{
    public interface IComplainTypeCategoryRepository
    {

        Task<ComplainTypeCategoryModel> CreateAsync(ComplainTypeCategoryModel model);

        Task<ComplainTypeCategoryModel> FindAsync(int Id);
        Task<ComplainTypeCategoryModel> UpdateAsync(ComplainTypeCategoryModel model);

        Task<ComplainTypeCategoryModel> DeleteAsync(ComplainTypeCategoryModel model);

    }
}
