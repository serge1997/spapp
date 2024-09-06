using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class PatrolNeighborhoodModelMap : IEntityTypeConfiguration<PatrolNeighborhoodModel>
    {

        public void Configure(EntityTypeBuilder<PatrolNeighborhoodModel> builder)
        {
            builder.HasKey(pnei => pnei.Id);

            builder.HasOne(pnei => pnei.Patrol)
                .WithMany(patrol => patrol.PatrolNeighborhoods)
                .HasForeignKey(pnei => pnei.PatrolId);

            builder.HasOne(pnei => pnei.Neighborhood)
                .WithMany(nei => nei.PatrolNeighborhoods)
                .HasForeignKey(pnei => pnei.NeighbordhoodId);
        }
    }
}
