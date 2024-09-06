﻿using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Main.Repositories.Patrol;
using spapp.ModelViews;
using spapp.SpappContext;

namespace spapp.Controllers
{
    public class PatrolController(
        IPatrolRepository patrol,
        SpappContextDb context
    ) : Controller
    {
        private readonly IPatrolRepository _patrolRepository = patrol;
        private readonly SpappContextDb _context = context;
       

        [HttpGet]
        [Route("/patrol")]
        public IActionResult Index()
        {
            return View();
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
                return View(ex.Message);
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

                TempData["SuccessMessage"] = $"Patrouille enregistrée avec succès: {request.MunicipalitiesId!.Length}";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = $"Une est survenue en enregistrant une patrouille {ex.ToString()}";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
