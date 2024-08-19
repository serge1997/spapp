using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class ComplainTypeCategoryModelMap : IEntityTypeConfiguration<ComplainTypeCategoryModel>
    {

        public void Configure(EntityTypeBuilder<ComplainTypeCategoryModel> builder)
        {
            builder.HasKey(category => category.Id);
            //builder.HasMany(category => category.ComplainTypes);
        }
    }
}
