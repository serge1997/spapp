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

            base.OnModelCreating(modelBuilder);
        }
    }
}
