using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public sealed class UpdateRacerOptions
    {
        [Required]
        [StringLength(200)]
        public string Name 
        { 
            get; 
            set; 
        }

        //[Required]
        //public int VehicleId
        //{
        //    get;
        //    set;
        //}

        //[Required]
        //public List<Racer> Racers
        //{
        //    get;
        //    set;
        //}

        [Required]
        public DateTime TimeElapsed
        {
            get;
            set;
        }

        //[Required]
        //public int RaceId
        //{
        //    get;
        //    set;
        //}
    }
}
