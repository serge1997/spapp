using spapp.Models;

namespace spapp.Http.Response
{

    public record VehicleResource(
        int Id, 
        string LicensePlate,   
        string Brand,
        int BrandId,
        string Model,
        string Created_at,
        long? KM,
        string? Remark,
        int? Year
        );
    public class VehicleResponse
    {

        public List<VehicleResource> AsModelResponseList(List<VehicleModel> models)
        {
            return models.Select(vehicle => AsModelResponse(vehicle)).ToList();
        }

        public VehicleResource AsModelResponse(VehicleModel model)
        {
            return new VehicleResource(
                    model.Id,
                    model.LicensePlate,
                    model.VehicleBrandModel.Name,
                    model.VehicleBrandModel.Id,
                    model.Model,
                    model.Created_at.ToString("dd/MM/yyyy HH:mm"),
                    model.KM,
                    model.Remark,
                    model.Year
                );
        }
    }
}
