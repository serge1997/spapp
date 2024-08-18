using spapp.Models;

namespace spapp.Main.Repositories.AgentRank
{
    public interface IAgentRankRepository
    {
        Task<List<AgentRankModel>> GetAllAgentsRankAsync();
        Task<AgentRankModel> FindAGentRank(int Id);
    }
}
