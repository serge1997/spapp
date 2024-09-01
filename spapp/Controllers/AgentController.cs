using Microsoft.AspNetCore.Mvc;
using spapp.Http.Response;
using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Models;
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
        public async Task<IActionResult> Index()
        {
            try
            {
                List<AgentModel> agents = await _agentRepository.GetAllAsync();
                List<AgentResource> response = AgentResponse.AsModelListResponse(agents);

                return View(response);

            }catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une erreure est survenue en listants les agents: {ex.Message}";
                return View();
            }
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

        [HttpPost]
        [Route("/agent/create")]
        public async Task<IActionResult> Create(AgentModelView agentModelView)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    AgentModelView instance = await _agentRepository
                   .SetAgentModelView(
                       _cityRepository,
                       _agentRankRepository
                   );
                    TempData["ErrorMessage"] = $"Invalid some data. {ModelState.Values}";
                    return View(instance);
                }

                await _agentRepository.CreateAsync(agentModelView);
                TempData["SuccessMessage"] = "l'agent enregistré avec succès";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une erreure est survenue : {agentModelView.AgentRankId} {ex.ToString()}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        [Route("/agent/show/{Id}")]
        public async Task<IActionResult> Show(int Id)
        {
            try
            {
                AgentModel agent = await _agentRepository.FindAsync(Id);

                return View(AgentResponse.AsModelResponse(agent));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Une erreur est survenue: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
