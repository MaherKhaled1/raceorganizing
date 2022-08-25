CREATE PROCEDURE [dbo].[usp_PostVehicleToRacer]
	@vehicleid int,
	@racerid int
	--@racers NVARCHAR(4000)
AS
	INSERT INTO [dbo].[Racer_Vehicles]
		([RacerId], [VehicleId])
	VALUES
		(@racerid, @vehicleid)
	SELECT CAST(@@IDENTITY AS INT)