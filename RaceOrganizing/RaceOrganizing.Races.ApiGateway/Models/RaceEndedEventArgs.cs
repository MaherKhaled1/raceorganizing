using System;

namespace RaceOrganizing.Races.ApiGateway.Models
{
    public class RaceEndedEventArgs : EventArgs
    {
        public DateTime EndedAt { get; set; }

        public string Winner { get; set; }
    }
}
