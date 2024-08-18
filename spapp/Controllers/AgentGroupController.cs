using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.AgentGroup;
using spapp.Models;

namespace spapp.Controllers
{
    public class AgentGroupController(IAgentGroupRepository agentGroupRepository) : Controller
    {
        private readonly IAgentGroupRepository _agentGroupRepository = agentGroupRepository;

        [HttpGet]
        [Route("/api/agent-group")]
        public async Task<JsonResult> Index()
        {
            try
            {
                List<AgentGroupModel> results = await _agentGroupRepository.GetAllAgentsAsync();

                return Json(Results.Ok(results));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }

        [HttpGet]
        [Route("/api/agent-group/{Id}/{shortName}")]
        public async Task<JsonResult> Find(int Id, string shortName)
        {
            try
            {
                AgentGroupModel result = await _agentGroupRepository.FindAgentGroupAsync(Id, shortName);
                return Json(Results.Ok(result));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }
    }
}
