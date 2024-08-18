using spapp.SpappContext;

namespace spapp.Main.Repositories.Agent
{
    public class AgentRepository(SpappContextDb spappContextDb) : IAgentRepository
    {
        private readonly SpappContextDb _spappContextDb = spappContextDb;
    }
}
