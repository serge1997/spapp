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

        public async Task<List<ComplainTypeCategoryResource>> GetAllAsync()
        {
            List<ComplainTypeCategoryModel> response = await _spappContextDb
                .ComplainTypesCategories.ToListAsync();

            return new ComplainTypeCategoryResponse().AsModelListResponse(response);
        }

        public async Task<ComplainTypeCategoryResource> FindAsync(int Id)
        {
            ComplainTypeCategoryModel finded = await _spappContextDb
                .ComplainTypesCategories.FirstOrDefaultAsync(type => type.Id == Id);

            return new ComplainTypeCategoryResponse().AsModelResponse(finded);
        }

        public async Task<ComplainTypeCategoryResource> UpdateAsync(ComplainTypeCategoryRequest request)
        {
            ComplainTypeCategoryResource model = await FindAsync(request.Id);

            _spappContextDb.ComplainTypesCategories
                .Update(
                    new ComplainTypeCategoryModel()
                    {
                        Id = request.Id,
                        Name = request.Name,
                        Description = request.Description,
                        Updated_at = DateTime.Now,
                        IsActive = request.IsActive,

                    });

            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<ComplainTypeCategoryResource> DeleteAsync(int Id)
        {
            ComplainTypeCategoryResource model = await FindAsync(Id);

            _spappContextDb.ComplainTypesCategories
                .Where(type => type.Id == model.Id)
                .ExecuteDelete();

            await _spappContextDb.SaveChangesAsync();

            return model;
        }
    }
}
