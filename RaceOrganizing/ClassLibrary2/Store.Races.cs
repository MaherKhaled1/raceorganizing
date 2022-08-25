
using Microsoft.Data.SqlClient;
using RaceOrganizing.Races;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RaceOrganizing.Sql
{
    public sealed partial class Store : IRaceStore
    {
        public async Task<Race> CreateRace(string name, double distance, VehicleType vehicleType, string winner, DateTime endedAt)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_CreateRace]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@distance", distance);
            cmd.Parameters.AddWithValue("@vehicleType", (int)vehicleType);
            cmd.Parameters.AddWithValue("@winner", winner);
            cmd.Parameters.AddWithValue("@endedAt", endedAt);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            var raceId = (int)await cmd.ExecuteScalarAsync();

            return new Race()
            {
                Id = raceId,
                Name = name,
                Distance = distance,
                Type = vehicleType,
                Winner = winner,
                EndedAt = endedAt
            };
        }

        public async Task UpdateRace(int id, string name, double distance, VehicleType vehicleType, string winner, DateTime endedAt)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_UpdateRace]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@distance", distance);
            cmd.Parameters.AddWithValue("@vehicleType", (int)vehicleType);
            cmd.Parameters.AddWithValue("@winner", winner);
            cmd.Parameters.AddWithValue("@endedAt", endedAt);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Racer> CreateRacer(string name, DateTime timeElapsed)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_CreateRacer]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@timeElapsed", timeElapsed);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            var racerId = (int)await cmd.ExecuteScalarAsync();

            return new Racer()
            {
                Id = racerId,
                Name = name,
                TimeElapsed = timeElapsed
            };
        }

        public async Task UpdateRacer(int id, string name, DateTime timeElapsed)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_UpdateRacer]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@timeElapsed", timeElapsed);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<Vehicle> CreateVehicle(string brandName, VehicleType vehicleType, int maxSpeed)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_CreateVehicle]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.Parameters.AddWithValue("@vehicleType", (int)vehicleType);
            cmd.Parameters.AddWithValue("@maxSpeed", maxSpeed);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            var vehicleId = (int)await cmd.ExecuteScalarAsync();

            return new Vehicle()
            {
                Id = vehicleId,
                BrandName = brandName,
                Type = vehicleType,
                MaxSpeed = maxSpeed
            };
        }

        public async Task UpdateVehicle(int id, string brandName, VehicleType vehicleType, int maxSpeed)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_UpdateVehicle]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@brandName", brandName);
            cmd.Parameters.AddWithValue("@vehicleType", (int)vehicleType);
            cmd.Parameters.AddWithValue("@maxSpeed", maxSpeed);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();
        }

        public async Task<IEnumerable<Race>> GetRaces()
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetAllRaces]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            await con.OpenAsync();

            var races = new List<Race>();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    races.Add(RaceFromReader(dr));
                }
            }

            return races;
        }

        public async Task<Race> GetRace(int id)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetRace]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                if (await dr.ReadAsync())
                {
                    return (RaceFromReader(dr));
                }
            }

            return null;
        }

        public async Task<Racer> GetRacer(int id)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetRacer]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                if (await dr.ReadAsync())
                {
                    return (RacerFromReader(dr));
                }
            }

            return null;
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetVehicle]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                if (await dr.ReadAsync())
                {
                    return (VehicleFromReader(dr));
                }
            }

            return null;
        }

        public async Task<IEnumerable<RaceOfRacersRead>> GetRaceOfRacers(int id)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetRaceOfRacers]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();

            var raceOfRacers = new List<RaceOfRacersRead>();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    raceOfRacers.Add(RaceOfRacersFromReader(dr));
                }
            }

            return raceOfRacers;
        }

        public async Task<RaceOfRacersRead> GetLowestTimeElapsed(int id)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetLowestTimeElapsed]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);

            await con.OpenAsync();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    return RaceOfRacersFromReader(dr);
                }
            }

            return null;
        }

        public async Task<int> UpdateRaceWinner(int id, string winner, DateTime endedAt)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_UpdateRaceWinner]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@winner", winner);
            cmd.Parameters.AddWithValue("@endedAt", endedAt);
            //cmd.Parameters.AddWithValue("racers", racers);

            await con.OpenAsync();

            await cmd.ExecuteNonQueryAsync();

            return id;
        }

        public async Task<RacerVehicles> GetRacerVehicle(int racerId, int vehicleId)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_GetRacerVehicle]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@racerId", racerId);
            cmd.Parameters.AddWithValue("@vehicleId", vehicleId);

            await con.OpenAsync();

            using (SqlDataReader dr = await cmd.ExecuteReaderAsync())
            {
                while (await dr.ReadAsync())
                {
                    return (RacerVehicleFromReader(dr));
                }
            }

            return null;
        }

        public async Task<PostRacerInRace> PostRacerInRace(int raceId, int racerId)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_PostRacerInRace]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@raceid", raceId);
            cmd.Parameters.AddWithValue("@racerid", racerId);

            await con.OpenAsync();

            var Id = (int)await cmd.ExecuteScalarAsync();

            return new PostRacerInRace()
            {
                Id = Id,
                RacerId = racerId,
                Racers = new List<Racer>()
                {
                    new RacerWithRaceId()
                    {
                        RaceId = raceId,
                    }
                }
            };
        }

        public async Task<PostVehicleToRacer> PostVehicleToRacer(int vehicleId, int racerId)
        {
            using var con = new SqlConnection(this.storeOptions.ConnectionString);
            var cmd = new SqlCommand("[dbo].[usp_PostVehicleToRacer]", con)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@vehicleid", vehicleId);
            cmd.Parameters.AddWithValue("@racerid", racerId);

            await con.OpenAsync();

            var Id = (int)await cmd.ExecuteScalarAsync();

            return new PostVehicleToRacer()
            {
                Id = Id,
                RacerId = racerId,
                VehicleId = vehicleId
            };
        }

        private static RaceOfRacersRead RaceOfRacersFromReader(SqlDataReader dr)
        {
            return new RaceOfRacersRead()
            {
                Id = (int)dr["Race_Id"],
                Name = (string)dr["Race_Name"],
                Distance = (double)dr["Race_Distance"],
                Type = (VehicleType)dr["Race_VehicleType"],
                Racers = RacersFromReader(dr),
                Winner = (string)dr["Race_Winner"],
                EndedAt = (DateTime)dr["Race_EndedAt"]
            };
        }

        private static RacerVehicles RacerVehicleFromReader(SqlDataReader dr)
        {
            return new RacerVehicles()
            {
                RacerId = (int)dr["Racer_Id"],
                Name = (string)dr["Racer_Name"],
                VehicleId = (int)dr["Vehicle_Id"],
                BrandName = (string)dr["Vehicle_BrandName"],
                Type = (VehicleType)dr["Vehicle_VehicleType"],
                MaxSpeed = (int)dr["Vehicle_MaxSpeed"],
                    
            };
        }

        private static List<Racer> RacersFromReader(SqlDataReader dr)
        {
            return new List<Racer>()
            {
                new Racer()
                {
                    Id = (int)dr["RaceOfRacers_Id"],
                    Name = (string)dr["RaceOfRacers_Name"],
                    TimeElapsed = (DateTime)dr["RaceOfRacers_TimeElapsed"]
                }
            };
        }

        private static Race RaceFromReader(SqlDataReader dr)
        {
            return new Race()
            {
                Id = (int)dr["Race_Id"],
                Name = (string)dr["Race_Name"],
                Distance = (double)dr["Race_Distance"],
                Type = (VehicleType)dr["Race_VehicleType"],
                Winner = (string)dr["Race_Winner"],
                EndedAt = (DateTime)dr["Race_EndedAt"]
            };
        }

        private static Vehicle VehicleFromReader(SqlDataReader dr)
        {
            return new Vehicle()
            {
                Id = (int)dr["Vehicle_Id"],
                BrandName = (string)dr["Vehicle_BrandName"],
                Type = (VehicleType)dr["Vehicle_VehicleType"],
                MaxSpeed = (int)dr["Vehicle_MaxSpeed"]
            };
        }

        private static Racer RacerFromReader(SqlDataReader dr)
        {
            return new Racer()
            {
                Id = (int)dr["Racer_Id"],
                Name = (string)dr["Racer_Name"],
                TimeElapsed = (DateTime)dr["Racer_TimeElapsed"]
            };
        }
    }
}
