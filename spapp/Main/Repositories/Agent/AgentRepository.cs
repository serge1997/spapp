using spapp.Main.ModelsBuilder.Address;
using spapp.Main.ModelsBuilder.AgentModelBuilder;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Main.Repositories.Agent
{
    public class AgentRepository(
        SpappContextDb spappContextDb,
        ICityRepository cityRepository,
        IAgentRankRepository agentRankRepository,
        IAgentModelBuilder agentModelBuilder,
        IAddressModelBuilder addressModelBuilder
    ) : IAgentRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;
        private IAgentModelBuilder _agentModelBuilder = agentModelBuilder;
        private IAddressModelBuilder _addressModelBuilder = addressModelBuilder;


        public async Task<AgentModel> CreateAsync(AgentModelView agentModelView)
        {
            AgentModel agent = _agentModelBuilder
                .AddFullName(agentModelView.FullName)
                .AddUserName(agentModelView.Username)
                .AddPassword(agentModelView.Password)
                .AddCNINumber(agentModelView.CNINumber)
                .AddEmail(agentModelView.Email)
                .Build();

            AddressModel address = _addressModelBuilder
                .AddStreetName(agentModelView.Address.StreetName!)
                .AddCityId(agentModelView.Address.CityId)
                .AddMunicipalityId(agentModelView.Address.MunicipalityId)
                .AddNeighborhoodSectorId(agentModelView.Address.NeighborhoodSectorId)
                .AddNeighborhoodSectorId(agentModelView.Address.NeighborhoodSectorId)
                .AddLatitude(agentModelView.Address.Latitude)
                .AddLongitude(agentModelView.Address.Longitude)
                .AddIndication(agentModelView.Address.Indication)
                .AddOrigin(agentModelView.Address.Origin!)
                .Build();


            _spappContextDb.Addresses.Add(address);
            //_spappContextDb.Agents.Add(agent);

            await _spappContextDb.SaveChangesAsync();

            return agent;
        }

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
