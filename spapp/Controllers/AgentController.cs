using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.ModelViews;

namespace spapp.Controllers
{
    public class AgentController(
        IAgentRepository agentRepository,
        ICityRepository cityRepository,
        IAgentRankRepository agentRankRepository
    ) : Controller
    {
        private readonly IAgentRepository _agentRepository = agentRepository;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;

        [HttpGet]
        [Route("/agent")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/agent/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                AgentModelView agentModelView = await _agentRepository
                    .SetAgentModelView(
                        _cityRepository,
                        _agentRankRepository
                    );

                return View(agentModelView);
            }
            catch(Exception ex)
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
