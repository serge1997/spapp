using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.SpappContext.ModelsMap;

namespace spapp.SpappContext
{
    public class SpappContextDb(IConfiguration configuration) : DbContext
    {

        private readonly IConfiguration _configuration = configuration;
        

        public DbSet<CityModel> Cities { get; set; }
        public DbSet<MunicipalityModel> Municipalities { get; set; }
        public DbSet<NeighborhoodModel> Neighborhoods { get; set; }
        public DbSet<AgentGroupModel> AgentGroups { get; set; }
        public DbSet<AgentRankModel> AgentRanks { get; set; }
        public DbSet<ComplainTypeCategoryModel> ComplainTypesCategories { get; set; }
        public DbSet<ComplainTypeModel> ComplainTypes { set; get; }
        public DbSet<VehicleBrandModel> VehicleBrands { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<NeighborhoodSectorModel> NeighborhoodSectors { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetValue<string>("Database:ConnectionString"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityModelMap());
            modelBuilder.ApplyConfiguration(new MunicipalityModelMap());
            modelBuilder.ApplyConfiguration(new NeighborhoodModelMap());
            modelBuilder.ApplyConfiguration(new AgentGroupModelMap());
            modelBuilder.ApplyConfiguration(new AgentRankModelMap());
            modelBuilder.ApplyConfiguration(new ComplainTypeCategoryModelMap());
            modelBuilder.ApplyConfiguration(new ComplainTypeModelMap());
            modelBuilder.ApplyConfiguration(new VehicleBrandModelMap());
            modelBuilder.ApplyConfiguration(new VehicleModelMap());
            modelBuilder.ApplyConfiguration(new NeighborhoodSectorModelMap());
            modelBuilder.ApplyConfiguration(new AddressModelMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
