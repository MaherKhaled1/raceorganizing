CREATE PROCEDURE [dbo].[usp_UpdateRace]
	@id int,
	@name NVARCHAR(200),
	@distance float,
	@vehicleType int,
	@winner NVARCHAR(200),
	@endedAt DateTime
	--@racers NVARCHAR(4000)
AS
	UPDATE
		[dbo].[Races]
	SET
		[Name] = @name, [Distance] = @distance, [VehicleType] = @vehicleType, [Winner] = @winner, [EndedAt] = @endedAt
	WHERE
		[Id] = @id
