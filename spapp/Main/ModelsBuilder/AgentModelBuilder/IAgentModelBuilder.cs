using spapp.Main.ModelsBuilder.Address;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.AgentModelBuilder
{
    public interface IAgentModelBuilder
    {

        AgentModelBuilder AddFullName(string fullName);
        AgentModelBuilder AddUserName(string userName);
        AgentModelBuilder AddPassword(string password);
        AgentModelBuilder AddEmail(string? email);
        AgentModelBuilder AddCNINumber(string? cniNumber);
        AddressModelBuilder AddAddress();

        AgentModel Build();
    }
}
