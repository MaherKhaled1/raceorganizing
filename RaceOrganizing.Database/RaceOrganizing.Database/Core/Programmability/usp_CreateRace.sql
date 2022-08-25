CREATE PROCEDURE [dbo].[usp_CreateRace]
	@name NVARCHAR(200),
	@distance float,
	@vehicleType int,
	@winner NVARCHAR(200),
	@endedAt DateTime
	--@racers NVARCHAR(4000)
AS
	INSERT INTO [dbo].[Races]
		([Name], [Distance], [VehicleType], [Winner], [EndedAt])
	VALUES
		(@name, @distance, @vehicleType, @winner, @endedAt)
		
	SELECT CAST(@@IDENTITY AS INT)
