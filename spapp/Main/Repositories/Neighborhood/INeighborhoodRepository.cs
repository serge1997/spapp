﻿using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Neighborhood
{
    public interface INeighborhoodRepository
    {

        Task<NeighborhoodModel> CreateAsync(NeighborhoodModelView neighborhood);
        Task<List<NeighborhoodModel>> GetAllAsyncNeighborhood();
        Task<NeighborhoodModel> FindNeighborhoodByIdAsync(int Id);
        Task<List<NeighborhoodModel>> FindByNameAsync(string name);
        Task<NeighborhoodModel> UpdateAsync(NeighborhoodModel neighborhood);
        Task<List<NeighborhoodModel>> GetAllByMunicipality(string[] Municipality);
        Task<NeighborhoodModel> DeleteAsync(int Id);
    }
}
