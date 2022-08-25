CREATE PROCEDURE [dbo].[usp_PostRacerInRace]
	@raceid int,
	@racerid int
	--@racers NVARCHAR(4000)
AS
	INSERT INTO [dbo].[Race_Racers]
		([RaceId], [RacerId])
	VALUES
		(@raceid, @racerid)
	SELECT CAST(@@IDENTITY AS INT)