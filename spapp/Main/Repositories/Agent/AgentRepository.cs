using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using spapp.Http.Requests;
using spapp.Main.ModelsBuilder.Address;
using spapp.Main.ModelsBuilder.AgentModelBuilder;
using spapp.Main.Repositories.Address;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;
using System.Net;

namespace spapp.Main.Repositories.Agent
{
    public class AgentRepository(
        SpappContextDb spappContextDb,
        ICityRepository cityRepository,
        IAgentRankRepository agentRankRepository,
        IAgentModelBuilder agentModelBuilder,
        IAddressRepository addressRepository
    ) : IAgentRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;
        private IAgentModelBuilder _agentModelBuilder = agentModelBuilder;
        private IAddressRepository _addressRepository = addressRepository;


        public async Task<AgentModel> CreateAsync(AgentModelView agentModelView)
        {
            
            AddressModel address = await _addressRepository
                .CreateAsync(agentModelView.AddressRequest!);

            await _spappContextDb.SaveChangesAsync();


            AgentModel agent = _agentModelBuilder
                .AddFullName(agentModelView.FullName)
                .AddUserName(agentModelView.Username)
                .AddEmail(agentModelView.Email)
                .AddContact(agentModelView.Contact)
                .AddAgentGroupId(agentModelView.AgentGroupId)
                .AddAGentRankId(agentModelView.AgentRankId)
                .AddChilddrenQUantity(agentModelView.ChilddrenQuantity)
                .AddPassword(agentModelView.Password)
                .AddCNINumber(agentModelView.CNINumber)
                .AddAttestationNumber(agentModelView.AttestionNumber)
                .AddEmail(agentModelView.Email)
                .AddMaritalStatus(agentModelView.MaritalStatus)
                .AddAddress(
                    address,
                    agentModelView.Complement,
                    agentModelView.Indication,
                    agentModelView.HouseNumber
                 )
                .AddMatriculeNumber()
                .AddCreated()
                .Build();

            _spappContextDb.Agents.Add(agent);
            await _spappContextDb.SaveChangesAsync();

            return agent;
        }

        public async Task<List<AgentModel>> GetAllAsync()
        {
            return await _spappContextDb.Agents
                .Include(agent => agent.AgentGroup)
                .Include(agent => agent.AgentRank)
                .Include(agent => agent.Address.CityModel)
                .Include(agent => agent.Address.MunicipalityModel)
                .Include(agent => agent.Address.NeighborhoodModel)
                .Include(agent => agent.Address.NeighborhoodSectorModel)
                .ToListAsync();
        }

        public async Task<AgentModel> FindAsync(int Id)
        {
            return await _spappContextDb.Agents
                .Include(agent => agent.AgentGroup)
                .Include(agent => agent.AgentRank)
                .Include(agent => agent.Address.CityModel)
                .Include(agent => agent.Address.MunicipalityModel)
                .Include(agent => agent.Address.NeighborhoodModel)
                .Include(agent => agent.Address.NeighborhoodSectorModel)
                .FirstOrDefaultAsync(agent => agent.Id == Id);
        }

        public async Task<AgentModel> UpdateAsync(UpdateAgentRequest request)
        {
            AgentModel finded = await FindAsync(request.Id);
           
            if (finded is null)
            {
                throw new Exception($"Agent non rencontré: {finded!.Id}");
            }

            AddressModel address = await _addressRepository
               .FindOrCreate(new AddressRequest(
                   request.StreetName,
                   request.CityId,
                   request.MunicipalityId,
                   request.NeighborhoodId,
                   request.NeighborhoodSectorId
                   ), 
                   finded.AddressId
               );


            AgentModel agent = _agentModelBuilder
                            .SetEntity(finded)
                            .AddFullName(request.FullName)
                            .AddEmail(request.Email)
                            .AddContact(request.Contact)
                            .AddAGentRankId(request.AgentRankId)
                            .AddChilddrenQUantity(request.ChilddrenQuantity)
                            .AddCNINumber(request.CNINumber)
                            .AddEmail(request.Email)
                            .AddMaritalStatus(request.MaritalStatus)
                            .AddAddress(
                                address,
                                request.Complement,
                                request.Indication,
                                request.HouseNumber
                            )
                            .Build();

            _spappContextDb.Agents.Update(agent);
            await _spappContextDb.SaveChangesAsync();
            return agent;

        }

        public async Task<AgentModelView> SetAgentModelView()
        {
            AgentModelView instance = new();
            instance.AgentRanks = await _agentRankRepository.GetAllAgentsRankAsync();
            instance.Citys = await _cityRepository.GetAllCitiesAsync();

            return instance;
        }
    }
}
