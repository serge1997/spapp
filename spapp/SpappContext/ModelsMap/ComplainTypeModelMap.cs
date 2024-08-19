using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class ComplainTypeModelMap : IEntityTypeConfiguration<ComplainTypeModel>
    {

        public void Configure(EntityTypeBuilder<ComplainTypeModel> builder) 
        {
            builder.HasKey(complaintype => complaintype.Id);
            builder.HasOne(complaintype => complaintype.ComplainTypeCategory);
        }
    }
}
