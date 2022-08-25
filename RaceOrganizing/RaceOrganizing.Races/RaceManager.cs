using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceOrganizing.Races
{
    public sealed class RaceManager : IRaceManager
    {
        private readonly IRaceStore raceStore;

        //delegate
        public delegate void RaceEndedHandler(int raceId, string winner, DateTime EndedAt);
        //event
        public event RaceEndedHandler RaceEnded;

        public RaceManager(IRaceStore raceStore)
        {
            this.raceStore = raceStore;
            this.RaceEnded += RaceManager_RaceEnded;
        }

        private void RaceManager_RaceEnded(int raceId, string winner, DateTime EndedAt)
        {
            this.UpdateRaceWinner(raceId, winner, EndedAt);
        }

        public async Task<Race> CreateRace(string race, double distance, VehicleType vehicleType, string winner, DateTime endedAt)
        {
            var Race = await this.raceStore.CreateRace(race, distance, vehicleType, winner, endedAt);

            return Race;
        }

        public async Task<int> UpdateRace(int id, string name, double distance, VehicleType vehicleType, string winner, DateTime endedAt)
        {
            await this.raceStore.UpdateRace(id, name, distance, vehicleType, winner, endedAt);

            //this.RaceEnded(id, endedAt, winner);

            return id;
        }

        public async Task<IEnumerable<Race>> GetRaces()
        {
            var Races = await this.raceStore.GetRaces();

            return Races;
        }

        public async Task<Race> GetRace(int id)
        {
            var Races = await this.raceStore.GetRace(id);

            return Races;
        }

        public async Task<Racer> GetRacer(int id)
        {
            var Racer = await this.raceStore.GetRacer(id);

            return Racer;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            var Racer = await this.raceStore.GetVehicle(id);

            return Racer;
        }

        public async Task<IEnumerable<RaceOfRacersRead>> GetRaceOfRacers(int id)
        {
            var Races = await this.raceStore.GetRaceOfRacers(id);

            return Races;
        }

        public async Task<RaceOfRacersRead> GetLowestTimeElapsed(int id)
        {
            var Races = await this.raceStore.GetLowestTimeElapsed(id);

            return Races;
        }

        public async Task<int> UpdateRaceWinner(int id, string winner, DateTime endedAt)
        {
            await this.raceStore.UpdateRaceWinner(id, winner, endedAt);

            this.RaceEnded(id, winner, endedAt);

            return id;
        }


        public async Task<RacerVehicles> GetRacerVehicle(int racerId, int vehicleId)
        {
            var Races = await this.raceStore.GetRacerVehicle(racerId, vehicleId);

            return Races;
        }

        public async Task<PostRacerInRace> PostRacerInRace(int raceId, int racerId)
        {
            var Races = await this.raceStore.PostRacerInRace(raceId, racerId);

            return Races;
        }

        public async Task<PostVehicleToRacer> PostVehicleToRacer(int vehicleId, int racerId)
        {
            var Races = await this.raceStore.PostVehicleToRacer(vehicleId, racerId);

            return Races;
        }

            public async Task<Racer> CreateRacer(string name, DateTime timeElapsed)
        {
            var Race = await this.raceStore.CreateRacer(name, timeElapsed);

            return Race;
        }

        public async Task<int> UpdateRacer(int id, string name, DateTime timeElapsed)
        {
            await this.raceStore.UpdateRacer(id, name, timeElapsed);

            return id;
        }

        public async Task<Vehicle> CreateVehicle(string brandName, VehicleType vehicleType, int maxSpeed)
        {
            var vehicle = await this.raceStore.CreateVehicle(brandName, vehicleType, maxSpeed);

            return vehicle;
        }

        public async Task<int> UpdateVehicle(int id, string brandName, VehicleType vehicleType, int maxSpeed)
        {
            await this.raceStore.UpdateVehicle(id, brandName, vehicleType, maxSpeed);

            return id;
        }

    }
}
