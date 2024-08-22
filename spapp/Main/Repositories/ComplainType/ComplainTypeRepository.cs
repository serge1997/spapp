using Microsoft.EntityFrameworkCore;
using spapp.Http.Requests;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;
using spapp.Helpers;
using Azure.Core;
using spapp.Main.Repositories.ComplainTypeCategory;

namespace spapp.Main.Repositories.ComplainType
{
    public class ComplainTypeRepository(SpappContextDb spappContextDb) : IComplainTypeRepository
    {
        private SpappContextDb _spappContextDb = spappContextDb;

        public async Task<List<ComplainTypeModel>> GellAllAsync()
        {
            return await _spappContextDb.ComplainTypes
                .Include(type => type.ComplainTypeCategory)
                .ToListAsync();
        }

        public async Task<ComplainTypeModel> CreateAsync(ComplainTypeModelView complainTypeModelView)
        {
            ComplainTypeModel model = new()
            {
                Name = complainTypeModelView.Name,
                Description = complainTypeModelView.Description,
                Priority = complainTypeModelView.Priority,
                Created_at = DateTime.Now,
                ComplainTypeCategoryId = complainTypeModelView.ComplainTypeCategoryId,
                PenalCode = complainTypeModelView.PenalCode,
            };

            _spappContextDb.ComplainTypes.Add(model);
            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<ComplainTypeModel> FindAsync(int Id)
        {
            return await _spappContextDb.ComplainTypes
                .Include(type => type.ComplainTypeCategory)
                .FirstOrDefaultAsync(type => type.Id == Id);
        }

        public async Task<ComplainTypeModel> UpdateAsync(ComplainTypeRequest request)
        {
            ComplainTypeModel model = await FindAsync(request.Id);

            if (model is not null)
            {
                model.Name = request.Name;
                model.Description = request.Description;
                model.Priority = request.Priority;
                model.Updated_at = DateTime.Now;
                model.IsActive = request.IsActive;
                model.PenalCode = request.PenalCode;

                return model;
            }
            throw new ArgumentException($"Le parametre {request.Id} fournit n'existe pas dans le système");
        }

        public async Task<ComplainTypeModel> DeleteAsync(int Id)
        {
            ComplainTypeModel model = await FindAsync(Id);
            _spappContextDb.ComplainTypes.Remove(model);
            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<ComplainTypeModelView> SetCompolainTypeModelView(IComplainTypeCategoryRepository complainTypeCategoryRepository)
        {
            ComplainTypeModelView instance = new();
            await instance.SetComplainTypeCategory(complainTypeCategoryRepository);
            return instance;
        }
    }
}
