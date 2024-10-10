using spapp.Http.Requests;
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
        Task<AgentModel> UpdateAsync(UpdateAgentRequest request);
        Task<AgentModelView> SetAgentModelView(HttpClient httpClient, string baseUrl);
    }
}
