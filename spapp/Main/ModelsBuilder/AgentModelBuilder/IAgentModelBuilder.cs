using spapp.Main.ModelsBuilder.Address;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.AgentModelBuilder
{
    public interface IAgentModelBuilder
    {

        IAgentModelBuilder AddFullName(string fullName);
        IAgentModelBuilder AddUserName(string userName);
        IAgentModelBuilder AddPassword(string password);
        IAgentModelBuilder AddEmail(string? email);
        IAgentModelBuilder AddCNINumber(string? cniNumber);
        IAgentModelBuilder AddMatriculeNumber(string matriculeNumber);

        AgentModel Build();
    }
}
