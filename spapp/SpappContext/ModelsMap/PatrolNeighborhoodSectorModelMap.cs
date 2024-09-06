using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class PatrolNeighborhoodSectorModelMap : IEntityTypeConfiguration<PatrolNeighborhoodSectorModel>
    {

        public void Configure(EntityTypeBuilder<PatrolNeighborhoodSectorModel> builder)
        {
            builder.HasKey(psector => psector.Id);

            builder.HasOne(psector => psector.Patrol)
                .WithMany(patrol => patrol.PatrolNeighborhoodSectors)
                .HasForeignKey(psector => psector.NeighbordhoodSectorId);

            builder.HasOne(psector => psector.Patrol)
                .WithMany(patrol => patrol.PatrolNeighborhoodSectors)
                .HasForeignKey(psector => psector.PatrolId);
            
        }
    }
}
