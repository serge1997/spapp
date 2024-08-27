using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.NeighborhoodSector
{
    public class NeighborhoodSectorRepository(SpappContextDb spappContextDb) : INeighborhoodSectorRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public async Task<List<NeighborhoodSectorModel>> GetAllAsync()
        {
            return await _spappContextDb.NeighborhoodSectors
                .Include(sector => sector.Municipality)
                .Include(sector => sector.Neighborhood.City)
                .ToListAsync();
        }

        public async Task<NeighborhoodSectorModel> CreateAsync(NeighborhoodSectorModelView modelView)
        {
            NeighborhoodSectorModel model = new()
            {
                Name = modelView.Name,
                MunicipalityId = 1,
                NeighborhoodId = modelView.NeighborhoodId,
                Longitude = modelView.Longitude,
                Latitude = modelView.Latitude,
                IsRiskArea = modelView.IsRiskArea,
                Observation = modelView.Observation,
                Created_at = DateTime.Now
            };
            

            _spappContextDb.NeighborhoodSectors.Add(model);
            await _spappContextDb.SaveChangesAsync();

            return model;
        }

        public async Task<NeighborhoodSectorModel> Find(int Id)
        {
            return await _spappContextDb.NeighborhoodSectors
                .Include(sector => sector.Neighborhood)
                .Include(sector => sector.Municipality.City)
                .FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<NeighborhoodSectorModelView> SetNeighborhoodSectorModelView(
            IMunicipalityRepository municipalityRepository,
            INeighborhoodRepository neighborhoodRepository
        )
        {
            NeighborhoodSectorModelView instance = new();
            instance.Municipalities = await municipalityRepository.GetAllMunicipalityAsync();
            instance.Neighborhoods = await neighborhoodRepository.GetAllAsyncNeighborhood();

            return instance;
        }

        public async Task<NeighborhoodSectorModel> DeleteAsync(int Id)
        {
            NeighborhoodSectorModel finded = await Find(Id);

            _spappContextDb.NeighborhoodSectors.Remove(finded);
            await _spappContextDb.SaveChangesAsync();

            return finded;
        }
    }
}
