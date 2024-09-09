namespace spapp.Http.Requests
{
    public record PatrolRequest(
        int DriverId,
        int VehicleId,
        string? Name,
        string? Observation,
        int[]? MembersId = null,
        int[]? MunicipalitiesId = null,
        int[]? NeighbordhoodsId = null,
        int[]? NeighbordhoodSectorsId = null
    );
    
}
