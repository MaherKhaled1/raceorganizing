using System;
using System.Collections.Generic;

namespace RaceOrganizing.Races
{
    public class RaceOfRacersBase
    {
        public int Id { get; set; }

        public List<Racer> Racers { get; set; }
    }
}
