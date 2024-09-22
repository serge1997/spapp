using System.ComponentModel.DataAnnotations;

namespace spapp.Models
{
    public class AddressModel
    {
        public int Id { get; set; }
        public string? StreetName { get; set; } 
     
        public int CityId { get; set; }
        public int MunicipalityId { get; set; }
        public int NeighborhoodId { get; set; }
        public int? NeighborhoodSectorId { get; set; }
       
        public string? Origin { get; set; }
        
        public DateTime Created_at {  get; set; }
        public DateTime? Updated_at { get; set; }
        public CityModel? CityModel { get;}
        public MunicipalityModel? MunicipalityModel { get;}
        public NeighborhoodModel? NeighborhoodModel { get;}
        public NeighborhoodSectorModel? NeighborhoodSectorModel { get; set; } = null;
        public List<UserModel> Users { get; set; }

    }
}
