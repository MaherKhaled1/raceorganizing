using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RaceOrganizing.Races
{
    public interface IRaceManager
    {
        Task<Race> CreateRace(string name, double distance, VehicleType vehicleType, string winner, DateTime endedAt);

        Task<int> UpdateRace(int id, string name, double distance, VehicleType vehicleType, string winner, DateTime endedAt);

        Task<IEnumerable<Race>> GetRaces();

        Task<Race> GetRace(int id);

        Task<Racer> GetRacer(int id);

        Task<Vehicle> GetVehicle(int id);

        Task<IEnumerable<RaceOfRacersRead>> GetRaceOfRacers(int id);

        Task<RaceOfRacersRead> GetLowestTimeElapsed(int id);

        Task<int> UpdateRaceWinner(int id, string winner, DateTime endedAt);

        Task<RacerVehicles> GetRacerVehicle(int racerId, int vehicleId);

        Task<PostRacerInRace> PostRacerInRace(int raceId, int racerId);

        Task<PostVehicleToRacer> PostVehicleToRacer(int vehicleId, int racerId);

        Task<Racer> CreateRacer(string name, DateTime timeElapsed);

        Task<int> UpdateRacer(int id, string name, DateTime timeElapsed);

        Task<Vehicle> CreateVehicle(string brandName, VehicleType vehicleType, int maxSpeed);

        Task<int> UpdateVehicle(int id, string brandName, VehicleType vehicleType, int maxSpeed);
    }
}
