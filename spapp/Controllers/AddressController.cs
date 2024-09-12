using Microsoft.AspNetCore.Mvc;
using spapp.Http.Response;
using spapp.Main.Repositories.Address;

namespace spapp.Controllers
{
    public class AddressController(IAddressRepository addressRepository) : Controller
    {
        private readonly IAddressRepository _addressRepository = addressRepository;

        [HttpGet]
        [Route("/api/address-by-streetname")]
        public async Task<JsonResult> GetByStreetName([FromQuery] string? streetname)
        {
            try
            {
                List<AddressResource> addresses = AddressResponse
                    .AsModelResponseList(await _addressRepository.FindByStreetName(streetname));

                return Json(Results.Ok(addresses));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound($"erreure, Verifier le(s) parametres de recherche: {ex.Message}"));
            }
        }
    }
}
