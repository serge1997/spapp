using Microsoft.AspNetCore.Mvc;
using spapp.Http.Requests;
using spapp.Main.Repositories.Complain;
using spapp.Models;

namespace spapp.Controllers
{
    public class ComplainController(IComplainRepository complainRepository) : Controller
    {
        private readonly IComplainRepository _complainRepository = complainRepository;

        [HttpGet]
        [Route("/complain")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/complain/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("/api/complain")]
        public async Task<JsonResult> CreateAgentWebComplain([FromBody]ComplainRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(Results.Ok(ModelState));
                    //return Json(BadRequest(ModelState));
                }

                ComplaintModel complain = await _complainRepository.CreateWebAgentComplain(request);
                return Json(Results.Ok(complain));
            }
            catch (Exception ex)
            {
                return Json(ex.ToString());
            }
        }
    }
}
