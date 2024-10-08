﻿using spapp.Http.Requests;
using spapp.Main.Repositories.ComplainTypeCategory;
using spapp.Models;
using spapp.ModelViews;


namespace spapp.Main.Repositories.ComplainType
{
    public interface IComplainTypeRepository
    {

        Task<List<ComplainTypeModel>> GellAllAsync();
        Task<ComplainTypeModel> CreateAsync(ComplainTypeModelView complainTypeModelView);

        Task<ComplainTypeModel> FindAsync(int Id);
        Task<ComplainTypeModel> UpdateAsync(ComplainTypeRequest request);
        Task<ComplainTypeModel> DeleteAsync(int Id);
        Task<ComplainTypeModelView> SetCompolainTypeModelView(IComplainTypeCategoryRepository complainTypeCategoryRepository);

    }
}
