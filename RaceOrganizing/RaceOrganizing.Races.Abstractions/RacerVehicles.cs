using System;
using System.Collections.Generic;

namespace RaceOrganizing.Races
{
    public class RacerVehicles
    {
        public int RacerId { get; set; }

        public string Name { get; set; }

        public int VehicleId { get; set; }

        public string BrandName { get; set; }

        public VehicleType Type { get; set; }

        public int MaxSpeed { get; set; }
    }
}
