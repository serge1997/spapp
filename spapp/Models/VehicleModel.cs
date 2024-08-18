namespace spapp.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
        //plaque d1imatriculation
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float KM { get; set; }
    }
}
