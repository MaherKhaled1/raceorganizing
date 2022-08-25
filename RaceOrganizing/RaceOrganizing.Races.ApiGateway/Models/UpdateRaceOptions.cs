using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public sealed class UpdateRaceOptions
    {
        [Required]
        [StringLength(200)]
        public string Name 
        { 
            get; 
            set; 
        }

        [Required]
        public double Distance
        {
            get;
            set;
        }

        [Required]
        public VehicleType VehicleType
        {
            get;
            set;
        }

        //[Required]
        //public List<Racer> Racers
        //{
        //    get;
        //    set;
        //}

        [Required]
        public string Winner
        {
            get;
            set;
        }

        [Required]
        public DateTime EndedAt
        {
            get;
            set;
        }
    }
}
