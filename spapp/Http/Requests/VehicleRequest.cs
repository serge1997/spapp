namespace spapp.Http.Requests
{
    public record VehicleRequest(
        int Id,
        string LicensePlate,
        int VehicleBrandId,
        string Model,
        long? KM,
        string? Remark,
        int Year
    );
}
