using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.AgentRank;
using spapp.Models;

namespace spapp.Controllers
{
    public class AgentRankController(IAgentRankRepository agentRankRepository) : Controller
    {
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;

        [HttpGet]
        [Route("/api/agent-rank")]
        public async Task<JsonResult> Index()
        {
            try
            {
                List<AgentRankModel> results = await _agentRankRepository.GetAllAgentsRankAsync();

                return Json(Results.Ok(results));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }

        [HttpGet]
        [Route("/api/agent-rank{Id}")]
        public async Task<JsonResult> FindAgentRank(int Id)
        {
            try
            {
                AgentRankModel result = await _agentRankRepository.FindAGentRank(Id);
                return Json(Results.Ok(result));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex));
            }
        }
    }
}
