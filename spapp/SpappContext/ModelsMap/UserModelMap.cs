using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class UserModelMap : IEntityTypeConfiguration<UserModel>
    {

        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(user => user.Id);

            builder.HasOne(user => user.Address)
                .WithMany(address => address.Users)
                .HasForeignKey(user => user.AddressId);
        }
    }
}
