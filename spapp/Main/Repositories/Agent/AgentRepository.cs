using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Agent
{
    public class AgentRepository(
        SpappContextDb spappContextDb,
        ICityRepository cityRepository,
        IAgentRankRepository agentRankRepository
    ) : IAgentRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;


        public async Task<AgentModelView> SetAgentModelView(
            ICityRepository cityRepository,
            IAgentRankRepository agentRankRepository
         )
        {
            AgentModelView instance = new();
            instance.AgentRanks = await _agentRankRepository.GetAllAgentsRankAsync();
            instance.Citys = await _cityRepository.GetAllCitiesAsync();

            return instance;
        }
    }
}
