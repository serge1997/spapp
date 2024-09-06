using spapp.Helpers;
using spapp.Models;

namespace spapp.Http.Response
{
    public sealed record AgentResource(
        int Id,
        string FullName,
        string UserName,
        string MatriculeNumber,
        string AgentGroup,
        int AgentGroupId,
        string AgentRank,
        int AgentRankId,
        string? Email,
        string? Contact,
        string? CNINumber,
        string? AttestationNumber,
        string? BloodGroup,
        //address
        int AddresId,
        string City,
        int CityId,
        string Municipality,
        int MunicipalityId,
        string Neighborhood,
        int NeighborhoodId,
        string? NeighborhoodSector,
        int? NeighborhoodSectorId,
        string? StreetName,
        string? Complement,
        string? Indication,
        int? HouseNumber,
        //familly
        int? ChilddrenQuantity,
        string MaritalStatus,
        string Created_at
    );


    public static class AgentResponse
    {

        public static List<AgentResource> AsModelListResponse(List<AgentModel> agents)
        {
            return agents.Select(agent => AsModelResponse(agent)).ToList();
        }

        public static AgentResource AsModelResponse(AgentModel agent)
        {
            return new AgentResource(
                    agent.Id,
                    agent.FullName,
                    agent.Username,
                    agent.MatriculeNumber,
                    agent.AgentGroup.Name,
                    agent.AgentGroupId,
                    agent.AgentRank.Name,
                    agent.AgentRankId,
                    agent.Email,
                    agent.Contact,
                    agent.CNINumber,
                    agent.AttestionNumber,
                    agent.BloodGroup,
                    agent.AddressId,
                    agent.Address.CityModel!.Name,
                    agent.Address.CityId,
                    agent.Address.MunicipalityModel!.Name,
                    agent.Address.MunicipalityId,
                    agent.Address.NeighborhoodModel!.Name,
                    agent.Address.NeighborhoodId,
                    agent.Address.NeighborhoodSectorModel?.Name,
                    agent.Address.NeighborhoodSectorId,
                    agent.Address.StreetName,
                    agent.Complement,
                    agent.Indication,
                    agent.HouseNumber,              
                    agent.ChilddrenQuantity,
                    agent.MaritalStatus.Marital(),
                    agent.Created_at.ToString("dd/MM/yyyy")
                );
        }
    }
    
}
