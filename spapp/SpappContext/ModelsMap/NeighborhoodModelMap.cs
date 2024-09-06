using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class NeighborhoodModelMap : IEntityTypeConfiguration<NeighborhoodModel>
    {

        public void Configure(EntityTypeBuilder<NeighborhoodModel> builder)
        { 
            builder.HasKey(nei => nei.Id);
            builder.HasOne(nei => nei.Municipality);
            builder.HasOne(nei => nei.City);

            builder.HasMany(nei => nei.PatrolNeighborhoods)
                .WithOne(pnei => pnei.Neighborhood)
                .HasForeignKey(pnei => pnei.NeighbordhoodId);
        }
    }
}
