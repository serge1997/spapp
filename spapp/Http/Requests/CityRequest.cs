using System.Text.Json.Serialization;

namespace spapp.Http.Requests

{
    public record CityRequest(
    int Id,
    string Name,
    string Region,
    string? District,
    float? Latitude,
    float? Longitude,
    long ?Area,
    long? Population);   
}
