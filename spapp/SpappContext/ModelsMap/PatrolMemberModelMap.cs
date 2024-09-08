using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using spapp.Models;

namespace spapp.SpappContext.ModelsMap
{
    public class PatrolMemberModelMap : IEntityTypeConfiguration<PatrolMemberModel>
    {

        public void Configure(EntityTypeBuilder<PatrolMemberModel> builder) 
        {
            builder.HasKey(pmember => pmember.Id);

            builder.HasOne(pmember => pmember.Patrol)
                .WithMany(patrol => patrol.PatrolMembers)
                .HasForeignKey(pmember => pmember.PatrolId);

            builder.HasOne(pmember => pmember.Agent)               
                .WithOne()
                .HasForeignKey<PatrolMemberModel>(pmember => pmember.AgentId);
        }
    }
}
