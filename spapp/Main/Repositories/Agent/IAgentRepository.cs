using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Models;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Agent
{
    public interface IAgentRepository
    {

        Task<AgentModel> CreateAsync(AgentModelView agentModelView);
        Task<AgentModelView> SetAgentModelView(
            ICityRepository cityRepository,
            IAgentRankRepository agentRankRepository
         );
    }
}
