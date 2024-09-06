using spapp.Enums;
using spapp.Main.ModelsBuilder.Address;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.AgentModelBuilder
{
    public interface IAgentModelBuilder
    {

        IAgentModelBuilder SetEntity(AgentModel entity);
        IAgentModelBuilder AddFullName(string fullName);
        IAgentModelBuilder AddUserName(string userName);
        IAgentModelBuilder AddPassword(string password);
        IAgentModelBuilder AddEmail(string? email);
        IAgentModelBuilder AddContact(string? contact);
        IAgentModelBuilder AddCNINumber(string? cniNumber);
        IAgentModelBuilder AddAttestationNumber(string? attestationNumber);
        IAgentModelBuilder AddMatriculeNumber();
        IAgentModelBuilder AddChilddrenQUantity(int? childdrenQuantity);
        IAgentModelBuilder AddAgentGroupId(int agentGroupId);
        IAgentModelBuilder AddAGentRankId(int agentRankId);
        IAgentModelBuilder AddMaritalStatus(MaritalStatusEnum maritalStatus);
        IAgentModelBuilder AddCreated();
        IAgentModelBuilder AddAddress(
            AddressModel address,
            string? Complement,
            string? Indication,
            int? HouseNumber
        );
        AgentModel Build();
    }
}
