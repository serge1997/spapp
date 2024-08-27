namespace spapp.Http.Requests
{
    public record NeighborhoodSectorRequest(
        int Id,
        string Name,
        int MunicipalityId,
        int NeighborhoodId,
        bool IsRiskArea,
        double? Latitiude,
        double? Longitiude,
        string? Observation
    );
    
}
