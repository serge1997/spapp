namespace spapp.Http.Requests
{
    public record PatrolRequest(
        int DriverId,
        int VehicleId,
        string? Name,
        string? Observation,
        int[]? MembersId,
        int[]? MunicipalitiesId,
        int[]? NeighbordhoodsId,
        int[]? NeighbordhoodSectorsId
    );
    
}
