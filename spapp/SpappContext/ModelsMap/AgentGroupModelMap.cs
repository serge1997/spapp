using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class AgentGroupModelMap : IEntityTypeConfiguration<AgentGroupModel>
    {

        public void Configure(EntityTypeBuilder<AgentGroupModel> builder)
        {
            builder.HasKey(agent => agent.Id);
        }
    }
}
