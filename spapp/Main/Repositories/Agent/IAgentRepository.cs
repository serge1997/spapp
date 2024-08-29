using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.ModelViews;

namespace spapp.Main.Repositories.Agent
{
    public interface IAgentRepository
    {

        Task<AgentModelView> SetAgentModelView(
            ICityRepository cityRepository,
            IAgentRankRepository agentRankRepository
         );
    }
}
