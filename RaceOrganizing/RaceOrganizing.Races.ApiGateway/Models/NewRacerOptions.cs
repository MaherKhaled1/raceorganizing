using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public sealed class NewRacerOptions
    {
        [Required]
        [StringLength(200)]
        public string Name 
        { 
            get; 
            set; 
        }

        [Required]
        public DateTime TimeElapsed
        {
            get;
            set;
        }
    }
}
