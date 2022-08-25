namespace RaceOrganizing.Races.ApiGateway.Models
{
    public class Vehicle
    {   
        public int Id { get; set; }

        public string BrandName { get; set; }

        public VehicleType Type { get; set; }

        public int MaxSpeed { get; set; }

    }
}
