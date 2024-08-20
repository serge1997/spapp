using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.ComplainTypeCategory
{
    public class ComplainTypeCategoryRepository(SpappContextDb spappContextDb) : IComplainTypeCategoryRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public async Task<ComplainTypeCategoryModel> CreateAsync(ComplainTypeCategoryRequest request)
        {
            ComplainTypeCategoryModel model = new()
            {
                Name = request.Name,
                Description = request.Description,
                IsActive = request.IsActive,
                Created_at = DateTime.Now
            };

            _spappContextDb.ComplainTypesCategories.Add(model);
            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<List<ComplainTypeCategoryModel>> GetAllAsync()
        {
            List<ComplainTypeCategoryModel> response = await _spappContextDb
                .ComplainTypesCategories.ToListAsync();

            return response;
        }

        public async Task<ComplainTypeCategoryModel> FindAsync(int Id)
        {
            ComplainTypeCategoryModel finded = await _spappContextDb
                .ComplainTypesCategories.FirstOrDefaultAsync(type => type.Id == Id);

            return finded;
        }

        public async Task<ComplainTypeCategoryModel> UpdateAsync(ComplainTypeCategoryRequest request)
        {

            ComplainTypeCategoryModel model = await FindAsync(request.Id);

            model.Name = request.Name;
            model.Description = request.Description;
            model.Updated_at = DateTime.Now;
            model.IsActive = request.IsActive;

            _spappContextDb.ComplainTypesCategories.Update(model);

            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<ComplainTypeCategoryModel> DeleteAsync(int Id)
        {
            ComplainTypeCategoryModel model = await FindAsync(Id);

            _spappContextDb.ComplainTypesCategories.Remove(model);

            await _spappContextDb.SaveChangesAsync();

            return model;
        }
    }
}
