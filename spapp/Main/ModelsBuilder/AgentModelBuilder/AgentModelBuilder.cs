using spapp.Enums;
using spapp.Main.ModelsBuilder.Address;
using spapp.Models;

namespace spapp.Main.ModelsBuilder.AgentModelBuilder
{
    public class AgentModelBuilder : IAgentModelBuilder
    {
        private AgentModel _agent = new();

        public IAgentModelBuilder AddFullName(string fullName)
        {
            this._agent.FullName = fullName;
            return this;
        }

        public IAgentModelBuilder AddUserName(string userName)
        {
            this._agent.Username = userName;
            return this;
        }
        public IAgentModelBuilder AddPassword(string password)
        {
            this._agent.Password = password;
            return this;
        }
        public IAgentModelBuilder AddEmail(string? email)
        {
            this._agent.Email = email;
            return this;
        }

        public IAgentModelBuilder AddContact(string? contact)
        {
            this._agent.Contact = contact;
            return this;
        }
        public IAgentModelBuilder AddCNINumber(string? cniNumber)
        {
            this._agent.CNINumber = cniNumber;
            return this;
        }

        public IAgentModelBuilder AddAttestationNumber(string? attestationNumber)
        {
            this._agent.AttestionNumber = attestationNumber;
            return this;
        }

        public IAgentModelBuilder AddMatriculeNumber()
        {
            string name = this._agent.FullName;
            string first = name.Split(" ")[0];

            string protocol = first[0] + DateTime.Now
                .ToString("dd/MM/yyyyHHmmssfff")
                .Replace("/", "");

            this._agent.MatriculeNumber = protocol;
            return this;
        }

        public IAgentModelBuilder AddChilddrenQUantity(int? childdrenQuantity)
        {
            this._agent.ChilddrenQuantity = childdrenQuantity;
            return this;
        }

        public IAgentModelBuilder AddAgentGroupId(int agentGroupId)
        {
            this._agent.AgentGroupId = agentGroupId;
            return this;
        }

        public IAgentModelBuilder AddAGentRankId(int agentRankId)
        {
            this._agent.AgentRankId = agentRankId;
            return this;
        }

        public IAgentModelBuilder AddMaritalStatus(MaritalStatusEnum maritalStatus)
        {
            this._agent.MaritalStatus = maritalStatus;
            return this;
        }

        public IAgentModelBuilder AddCreated()
        {
            this._agent.Created_at = DateTime.Now;
            return this;
        }
        public IAgentModelBuilder AddAddress(AddressModel address)
        {
            this._agent.AddressId = address.Id;
            return this;
        }

        public AgentModel Build()
        {
            return this._agent;
        }
    }
}
