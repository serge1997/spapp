using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class VehicleBrandModelMap : IEntityTypeConfiguration<VehicleBrandModel>
    {

        public void Configure(EntityTypeBuilder<VehicleBrandModel> builder)
        {
            builder.HasKey(brand => brand.Id);
            builder.HasMany(brand => brand.Vehicles)
                .WithOne(vehicle => vehicle.VehicleBrandModel)
                .HasForeignKey(vehicle => vehicle.VehicleBrandId);
        }
    }
}
