using System;
using System.Collections.Generic;

namespace RaceOrganizing.Races
{
    public class RaceOfRacersRead : RaceOfRacersBase
    {
        public string Name { get; set; }

        public double Distance { get; set; }

        public VehicleType Type { get; set; }

        public string Winner { get; set; }

        public DateTime EndedAt { get; set; }
    }
}
