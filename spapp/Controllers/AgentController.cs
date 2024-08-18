using Microsoft.AspNetCore.Mvc;
using spapp.Main.Repositories.Agent;

namespace spapp.Controllers
{
    public class AgentController(IAgentRepository agentRepository) : Controller
    {
        private readonly IAgentRepository _agentRepository = agentRepository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
