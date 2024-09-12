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

        [HttpGet]
        [Route("/api/address-by-id/{Id}")]
        public async Task<JsonResult> FindById(int Id)
        {
            try
            {
                AddressResource address = AddressResponse.AsModelResponse(
                    await _addressRepository.FindById(Id)
                );

                return Json(Results.Ok(address));
            }
            catch(Exception ex)
            {
                return Json(Results.NotFound(ex.Message));
            }
        }
    }
}
