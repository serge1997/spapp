using spapp.Main.ModelsBuilder.Address;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.AgentModelBuilder
{
    public class AgentModelBuilder : IAgentModelBuilder
    {
        private AgentModel _agent = new();

        public AgentModelBuilder AddFullName(string fullName)
        {
            this._agent.FullName = fullName;
            return this;
        }
        public AddressModelBuilder AddAddress()
        {
            return new AddressModelBuilder();
        }

        public AgentModelBuilder AddUserName(string userName)
        {
            this._agent.Username = userName;
            return this;
        }
        public AgentModelBuilder AddPassword(string password)
        {
            this._agent.Password = password;
            return this;
        }
        public AgentModelBuilder AddEmail(string? email)
        {
            this._agent.Email = email;
            return this;
        }
        public AgentModelBuilder AddCNINumber(string? cniNumber)
        {
            this._agent.CNINumber = cniNumber;
            return this;
        }
        public AgentModel Build()
        {
            return this._agent;
        }
    }
}
