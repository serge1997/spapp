using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class VehicleModelMap : IEntityTypeConfiguration<VehicleModel>
    {

        public void Configure(EntityTypeBuilder<VehicleModel> builder) 
        { 
            builder.HasKey(vehicle => vehicle.Id);
            builder.HasOne(vehicle => vehicle.VehicleBrandModel)
                .WithMany(brand => brand.Vehicles)
                .HasForeignKey("VehicleBrandId");
        }
    }
}
