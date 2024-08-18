using spapp.Models;

namespace spapp.Main.Repositories.AgentGroup
{
    public interface IAgentGroupRepository
    {
        Task<List<AgentGroupModel>> GetAllAgentsAsync();
        Task<AgentGroupModel> FindAgentGroupAsync(int Id, string shortName);
    }
}
