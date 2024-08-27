using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class NeighborhoodSectorModelMap : IEntityTypeConfiguration<NeighborhoodSectorModel>
    {

        public void Configure(EntityTypeBuilder<NeighborhoodSectorModel> builder)
        {
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.Municipality)
                .WithMany(mun => mun.NeighborhoodSectors)
                .HasForeignKey(s => s.MunicipalityId);

            builder.HasOne(s => s.Neighborhood)
                .WithMany(nei => nei.NeighborhoodSectors)
                .HasForeignKey(s => s.NeighborhoodId);
        }
    }
}
