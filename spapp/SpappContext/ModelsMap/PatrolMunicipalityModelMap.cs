using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class PatrolMunicipalityModelMap : IEntityTypeConfiguration<PatrolMunicipalityModel>
    {

        public void Configure(EntityTypeBuilder<PatrolMunicipalityModel> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(mun => mun.Patrol)
                .WithMany(patrol => patrol.PatrolMunicipalities)
                .HasForeignKey(mun => mun.PatrolId);

            builder.HasOne(pmun => pmun.Municipality)
                .WithMany(mun => mun.PatrolMunicipalities)
                .HasForeignKey(pmun => pmun.MunicipalityId);

        }
    }
}
