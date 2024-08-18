using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class MunicipalityModelMap : IEntityTypeConfiguration<MunicipalityModel>
    {

        public void Configure(EntityTypeBuilder<MunicipalityModel> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(mun => mun.Id);
            entityTypeBuilder.HasOne(mun => mun.City);
        }
    }
}
