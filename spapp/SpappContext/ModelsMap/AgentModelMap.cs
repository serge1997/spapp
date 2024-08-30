using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class AgentModelMap : IEntityTypeConfiguration<AgentModel>
    {

        public void Configure(EntityTypeBuilder<AgentModel> builder) 
        { 
            builder.HasKey(agent => agent.Id);
            builder.HasOne(agent => agent.Address)
                .WithMany()
                .HasForeignKey(agent => agent.AddressId);

            
        }
    }
}
