using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class AddressModelMap : IEntityTypeConfiguration<AddressModel>
    {
        public void Configure(EntityTypeBuilder<AddressModel> builder) 
        {
            builder.HasKey(add => add.Id);

            builder.HasOne(add => add.CityModel)
                .WithMany()
                .HasForeignKey(add => add.CityId);

            builder.HasOne(add => add.MunicipalityModel)
                .WithMany()
                .HasForeignKey(add => add.MunicipalityId);

            builder.HasOne(add => add.NeighborhoodModel)
                .WithMany()
                .HasForeignKey(add => add.NeighborhoodId);

            builder.HasOne(add => add.NeighborhoodSectorModel)
                .WithMany()
                .HasForeignKey(add => add.NeighborhoodSectorId);

            builder.HasMany(address => address.Users)
                .WithOne(user => user.Address)
                .HasForeignKey(user => user.AddressId);
        }
    }
}
