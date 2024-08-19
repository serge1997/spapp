using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.ComplainTypeCategory
{
    public class ComplainTypeCategoryRepository(SpappContextDb spappContextDb) : IComplainTypeCategoryRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public async Task<ComplainTypeCategoryModel> CreateAsync(ComplainTypeCategoryModel model)
        {

        }

        public async Task<ComplainTypeCategoryModel> FindAsync(int Id)
        {

        }

        public async Task<ComplainTypeCategoryModel> UpdateAsync(ComplainTypeCategoryModel model)
        {

        }

        public async Task<ComplainTypeCategoryModel> DeleteAsync(ComplainTypeCategoryModel model)
        {

        }
    }
}
