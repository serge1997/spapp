using Microsoft.EntityFrameworkCore;
using spapp.Models;
using spapp.SpappContext;

namespace spapp.Main.Repositories.AgentRank
{
    public class AgentRankRepository(SpappContextDb spappContextDb) : IAgentRankRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;


        public async Task<List<AgentRankModel>> GetAllAgentsRankAsync()
        {
            return await _spappContextDb.AgentRanks.ToListAsync();
        }

        public async Task<AgentRankModel> FindAGentRank(int Id)
        {
            AgentRankModel finded = await _spappContextDb
                .AgentRanks.FirstOrDefaultAsync(agent => agent.Id == Id);

            return finded;
        }
    }
}
