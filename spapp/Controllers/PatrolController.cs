using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Main.Repositories.Patrol;
using spapp.Main.Repositories.PatrolMember;
using spapp.Main.Repositories.PatrolMunicipality;
using spapp.Main.Repositories.PatrolNeighborhood;
using spapp.Main.Repositories.PatrolNeighborhoodSector;
using spapp.Models;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Controllers
{
    public class PatrolController(
        IPatrolRepository patrol,
        SpappContextDb context,
        IPatrolMunicipalityRepository patrolMunicipalityRepository,
        IPatrolNeighborhoodRepository patrolNeighborhoodRepository,
        IPatrolNeighborhoodSectorRepository patrolNeighborhoodSectorRepository,
        IPatrolMemberRepository patrolMemberRepository
    ) : Controller
    {
        private readonly IPatrolRepository _patrolRepository = patrol;
        private readonly SpappContextDb _context = context;
        private readonly IPatrolMunicipalityRepository _patrolMunicipalityRepository = patrolMunicipalityRepository;
        private readonly IPatrolNeighborhoodRepository _patrolNeighborhoodRepository = patrolNeighborhoodRepository;
        private readonly IPatrolNeighborhoodSectorRepository _patrolNeighborhoodSectorRepository = patrolNeighborhoodSectorRepository;
        private readonly IPatrolMemberRepository _patrolMemberRepository = patrolMemberRepository;


        [HttpGet]
        [Route("/patrol")]
        public async Task<IActionResult> Index()
        {
            try
            {
                List<PatrolModel> patrols = await _patrolRepository
                    .GetAllAsync();

                return View(patrols);
            }
            catch(Exception ex)
            {
                string message = $"Une erreure est survenue en listant les patrouilles: {ex.Message}";
                return View();
            }
        }



        [HttpGet]
        [Route("/patrol/create")]
        public async Task<IActionResult> Create()
        {
            try
            {
                PatrolModelView patrolModelView = await _patrolRepository
                    .SetPatrolModelView();

                return View(patrolModelView);
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une est survenue en enregistrant une patrouille {ex.ToString()}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [Route("/patrol/create")]
        public async Task<IActionResult> Create(PatrolRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    

                    PatrolModelView patrolModelView = await _patrolRepository
                   .SetPatrolModelView();

                    return View(patrolModelView);
                }
                _context.Database.BeginTransaction();

                TempData["SuccessMessage"] = $"Patrouille enregistrée avec succès: {request.MunicipalitiesId!.Length}";
                await _patrolRepository.CreateAsync(
                    request,
                    _patrolMunicipalityRepository,
                    _patrolNeighborhoodRepository,
                    _patrolNeighborhoodSectorRepository,
                    _patrolMemberRepository
                );
                _context.Database.CommitTransaction();
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                _context.Database.RollbackTransaction();
                TempData["ErrorMessage"] = $"Une est survenue en enregistrant une patrouille {ex.ToString()}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
