using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class PatrolModelMap : IEntityTypeConfiguration<PatrolModel>
    {

        public void Configure(EntityTypeBuilder<PatrolModel> builder)
        {
            builder.HasKey(patrol => patrol.Id);

            builder.HasOne(patrol => patrol.Vehicle)
                .WithOne(vehicle => vehicle.Patrol)
                .HasForeignKey<PatrolModel>(patrol => patrol.VehicleId);

            builder.HasOne(patrol => patrol.Driver)
                .WithOne(patrol => patrol.Patrol)
                .HasForeignKey<PatrolModel>(patrol => patrol.DriverId);

            builder.HasMany(patrol => patrol.PatrolMunicipalities)
                .WithOne(pmun => pmun.Patrol)
                .HasForeignKey(pmu => pmu.PatrolId);

            builder.HasMany(patrol => patrol.PatrolNeighborhoods)
                .WithOne(pnei => pnei.Patrol)
                .HasForeignKey(pnei => pnei.PatrolId);

            builder.HasMany(patrol => patrol.PatrolMembers)
                .WithOne(pmember => pmember.Patrol)
                .HasForeignKey(pmember => pmember.PatrolId);
            

        }
    }
}
