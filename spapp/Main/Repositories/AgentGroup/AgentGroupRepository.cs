using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.AgentGroup
{
    public class AgentGroupRepository(SpappContextDb spappContextDb) : IAgentGroupRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;

        public async Task<List<AgentGroupModel>> GetAllAgentsAsync()
        {
            return await _spappContextDb.AgentGroups.ToListAsync();
        }

        public async Task<AgentGroupModel> FindAgentGroupAsync(int Id, string shortName)
        {
            AgentGroupModel finded = await _spappContextDb.AgentGroups
                .FirstOrDefaultAsync(group => group.Id == Id && string.Equals(group.ShortName, shortName, StringComparison.OrdinalIgnoreCase));

            return finded;
        }

    }
}
