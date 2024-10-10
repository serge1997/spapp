using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class CityModelMap : IEntityTypeConfiguration<CityModel>
    {

        public void Configure(EntityTypeBuilder<CityModel> model)
        {
            //model.HasKey(city => city.Id);
            //model.Property(city => city.Name).IsRequired();
            //model.Property(city => city.Region).IsRequired();
            //model.HasMany(city => city.Municipalitys);
            //model.HasMany(city => city.Neighborhoods);
        }
    }
}
