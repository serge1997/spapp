using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Http.Response;
using spapp.Main.Repositories.Agent;
using spapp.Main.Repositories.AgentRank;
using spapp.Main.Repositories.City;
using spapp.Main.Repositories.Municipality;
using spapp.Main.Repositories.Neighborhood;
using spapp.Main.Repositories.NeighborhoodSector;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;
using System.Reflection;

namespace spapp.Controllers
{
    public class AgentController(
        IAgentRepository agentRepository,
        ICityRepository cityRepository,
        IAgentRankRepository agentRankRepository,
        IMunicipalityRepository municipalityRepository,
        INeighborhoodRepository neighborhoodRepository,
        INeighborhoodSectorRepository neighborhoodSectorRepository,
        SpappContextDb context
    ) : Controller
    {
        private readonly IAgentRepository _agentRepository = agentRepository;
        private readonly ICityRepository _cityRepository = cityRepository;
        private readonly IAgentRankRepository _agentRankRepository = agentRankRepository;
        private readonly IMunicipalityRepository _municipalityRepository = municipalityRepository;
        private readonly INeighborhoodRepository _neighbordRepository = neighborhoodRepository;
        private readonly INeighborhoodSectorRepository _neighbordRepositorySector = neighborhoodSectorRepository;
        private readonly SpappContextDb _context = context;

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
                _context.Database.BeginTransaction();

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

                _context.Database.CommitTransaction();
                TempData["SuccessMessage"] = "l'agent enregistré avec succès";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _context.Database.RollbackTransaction();
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

        [HttpGet]
        [Route("/agent/edit/{Id}")]
        public async Task<IActionResult> Edit(int Id)
        {
            try
            {
                AgentResource findAgent = AgentResponse.AsModelResponse(
                    await _agentRepository.FindAsync(Id));                                      
                return View(findAgent);

            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une erreure est survenue en listant les données de l'agent: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("/agent/update")]
        public async Task<IActionResult> Update(UpdateAgentRequest request)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    _context.Database.BeginTransaction();
                    var agent = await _agentRepository.UpdateAsync(request);
                    TempData["SuccessMessage"] = $"informations actualisées avec succes {request.AgentRankId}";
                   

                    _context.Database.CommitTransaction();

                    return RedirectToAction(nameof(Index));
                }           
                return Redirect($"/agent/edit/{request.Id}");


            }
            catch(Exception ex)
            {
                _context.Database.RollbackTransaction();
                TempData["ErrorMessage"] = $"une erreure est survenue en éditant l'agent: {ex.ToString()}";
                return RedirectToAction(nameof(Index)); 
            }
        }
    }
}
