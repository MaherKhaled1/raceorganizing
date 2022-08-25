using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public sealed class UpdateVehicleOptions
    {
        
        [Required]
        public string BrandName
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
        public int MaxSpeed
        {
            get;
            set;
        }

        //[Required]
        //public int RacerId
        //{
        //    get;
        //    set;
        //}
    }
}
