using Microsoft.AspNetCore.Mvc;
using RaceOrganizing.Races.ApiGateway.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceOrganizing.Races.ApiGateway
{
    public sealed class RacesController : Controller
    {
        private readonly IRaceManager raceManager;

        public RacesController(IRaceManager raceManager)
        {
            this.raceManager = raceManager;
        }

        [HttpPost]
        [Route("Races")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> CreateRace([FromBody] NewRaceOptions options)
        {
            var race = await this.raceManager.CreateRace(options.Name, options.Distance, options.VehicleType, options.Winner, options.EndedAt);
            return Ok(race);
        }

        [HttpPost]
        [Route("Races/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateRace([FromRoute] int id, [FromBody] UpdateRaceOptions options)
        {
            var race = await this.raceManager.UpdateRace(id, options.Name, options.Distance, options.VehicleType, options.Winner, options.EndedAt);
            return Ok(race);
        }

        [HttpGet]
        [Route("Races")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Models.Race>))]
        public async Task<IActionResult> GetRaces()
        {
            var races = await this.raceManager.GetRaces();
            return Ok(races);
        }

        [HttpGet]
        [Route("Races/{id}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> GetRace([FromRoute] int id)
        {
            var races = await this.raceManager.GetRace(id);
            return Ok(races);
        }

        [HttpGet]
        [Route("Vehicles/{id}")]
        [ProducesResponseType(200, Type = typeof(Models.Vehicle))]
        public async Task<IActionResult> GetVehcile([FromRoute] int id)
        {
            var races = await this.raceManager.GetVehicle(id);
            return Ok(races);
        }

        [HttpGet]
        [Route("RaceWithRacers/{id}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> GetRaceOfRacers([FromRoute] int id)
        {
            var races = await this.raceManager.GetRaceOfRacers(id);
            foreach (var race in races)
            {
                if (race.Racers != null)
                {
                    return Ok(races);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("RaceEnded/{id}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> RaceEnded([FromRoute] int id)
        {
            var races = await this.raceManager.GetRaceOfRacers(id);
            foreach (var race in races)
            {
                if (race.Racers != null)
                {
                    var lowestTimeElapsed = await this.raceManager.GetLowestTimeElapsed(id);
                    if (lowestTimeElapsed != null)
                    {
                        var racewinner = await this.raceManager.UpdateRaceWinner(lowestTimeElapsed.Id, lowestTimeElapsed.Winner, lowestTimeElapsed.EndedAt);

                        return Ok(racewinner);
                    }
                }
            }
            return NotFound();
        }

        [HttpGet]
        [Route("RacerVehicles/{racerId}/Vehicles/{vehicleId}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> GetRacerVehicles([FromRoute] int racerId, [FromRoute] int vehicleId)
        {
            var racervehicle = await this.raceManager.GetRacerVehicle(racerId, vehicleId);
            return Ok(racervehicle);
        }

        [HttpPost]
        [Route("Races/{raceId}/racers/{racerId}/Vehicles/{vehicleId}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> PostRacersInRace([FromRoute] int raceId, [FromRoute] int racerId, [FromRoute] int vehicleId)
        {
            var races = await this.raceManager.GetRace(raceId);
            var racer = await this.raceManager.GetRacer(racerId);
            var racervehicle = await this.raceManager.GetRacerVehicle(racerId, vehicleId);
            if (races != null && racer != null && racervehicle !=null)
            {
                if (races.Type == racervehicle.Type)
                {
                    var racerinrace = await this.raceManager.PostRacerInRace(raceId, racerId);
                    return Ok(racerinrace);
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("Vehicles/{vehicleId}/racers/{racerId}")]
        [ProducesResponseType(200, Type = typeof(Models.Race))]
        public async Task<IActionResult> PostVehicleToRacer([FromRoute] int vehicleId, [FromRoute] int racerId)
        {
            var vehicles = await this.raceManager.GetVehicle(vehicleId);
            var racer = await this.raceManager.GetRacer(racerId);
            if (vehicles != null && racer != null)
            {
                var racerinrace = await this.raceManager.PostVehicleToRacer(vehicleId, racerId);
                return Ok(racerinrace);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("Racer/{id}")]
        public async Task<IActionResult> GetRacer([FromRoute] int id)
        {
            var racer = await this.raceManager.GetRacer(id);
            return Ok(racer);
        }

        [HttpPost]
        [Route("Racer")]
        [ProducesResponseType(200, Type = typeof(Models.Racer))]
        public async Task<IActionResult> CreateRacer([FromBody] NewRacerOptions options)
        {
            var racer = await this.raceManager.CreateRacer(options.Name, options.TimeElapsed);
            return Ok(racer);
        }

        [HttpPost]
        [Route("Racer/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateRacer([FromRoute] int id, [FromBody] UpdateRacerOptions options)
        {
            var racer = await this.raceManager.UpdateRacer(id, options.Name, options.TimeElapsed);
            return Ok(racer);
        }

        [HttpPost]
        [Route("Vehicle")]
        [ProducesResponseType(200, Type = typeof(Models.Vehicle))]
        public async Task<IActionResult> CreateVehicle([FromBody] NewVehicleOptions options)
        {
            var vehicle = await this.raceManager.CreateVehicle(options.BrandName,/*options.Racers, */options.VehicleType, options.MaxSpeed);
            return Ok(vehicle);
        }

        [HttpPost]
        [Route("Vehicle/{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, [FromBody] UpdateVehicleOptions options)
        {
            var vehicle = await this.raceManager.UpdateVehicle(id, options.BrandName,/*options.Racers, */options.VehicleType, options.MaxSpeed);
            return Ok(vehicle);
        }

    }
}
