using spapp.Helpers;
using spapp.Models;

namespace spapp.Http.Response
{
    public sealed record AgentResource(
        int Id,
        string FullName,
        string MatriculeNumber,
        string AgentGroup,
        string AgentRank,
        string? Email,
        string? Contact,
        //address
        string City,
        string Municipality,
        string Neighborhood,
        string? NeighborhoodSector,
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
                    agent.MatriculeNumber,
                    agent.AgentGroup.Name,
                    agent.AgentRank.Name,
                    agent.Email,
                    agent.Contact,
                    agent.Address.CityModel!.Name,
                    agent.Address.MunicipalityModel!.Name,
                    agent.Address.NeighborhoodModel!.Name,
                    agent.Address.NeighborhoodSectorModel?.Name,
                    agent.ChilddrenQuantity,
                    agent.MaritalStatus.Marital(),
                    agent.Created_at.ToString("dd/MM/yyyy")

                );
        }
    }
    
}
