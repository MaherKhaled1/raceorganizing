using System;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public class Racer
    {
        public string Name { get; set; }

        public VehicleType VehicleType { get; set; }

        public DateTime TimeElapsed { get; set; }
    }
}
