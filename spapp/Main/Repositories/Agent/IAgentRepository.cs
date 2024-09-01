using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Agent
{
    public interface IAgentRepository
    {

        Task<AgentModel> CreateAsync(AgentModelView agentModelView);
        Task<List<AgentModel>> GetAllAsync();
        Task<AgentModel> FindAsync(int Id);
        Task<AgentModelView> SetAgentModelView(
            ICityRepository cityRepository,
            IAgentRankRepository agentRankRepository
         );
    }
}
