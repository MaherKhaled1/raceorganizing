CREATE PROCEDURE [dbo].[usp_GetLowestTimeElapsed]
	@id int

AS
	SELECT
	-- races info
		races.[Id] AS Race_Id, races.[Name] AS Race_Name, races.[Distance] AS Race_Distance,
		races.[VehicleType] AS Race_VehicleType, races.Winner As Race_Winner, races.EndedAt As Race_EndedAt,

	-- racer info
		racer.Id As RaceOfRacers_Id,  racer.Name As RaceOfRacers_Name, MIN(racer.TimeElapsed) As RaceOfRacers_TimeElapsed

	FROM [dbo].[Races] races
	JOIN [dbo].[Race_Racers] raceofracers ON races.Id = raceofracers.RaceId
	JOIN [dbo].[Racers] racer ON racer.Id = raceofracers.RacerId
	WHERE
		races.Id = @id