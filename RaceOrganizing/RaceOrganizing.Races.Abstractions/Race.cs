using System;
using System.Collections.Generic;

namespace RaceOrganizing.Races
{
    public class Race
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Distance { get; set; }

        public VehicleType Type { get; set; }

        //public List<Racer> Racers { get; set; }
        public int RacerId { get; set; }

        public string Winner { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
