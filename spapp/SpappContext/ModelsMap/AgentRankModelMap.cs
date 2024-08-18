using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class AgentRankModelMap : IEntityTypeConfiguration<AgentRankModel>
    {
        public void Configure(EntityTypeBuilder<AgentRankModel> builder)
        { 
            builder.HasKey(agent =>  agent.Id);
        }
    }
}
