using System;
using System.Collections.Generic;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public class Race
    {
        public string Name { get; set; }

        public double Distance { get; set; }

        public VehicleType Type { get; set; }

        public List<Racer> Racers { get; set; }

        public string Winner { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
