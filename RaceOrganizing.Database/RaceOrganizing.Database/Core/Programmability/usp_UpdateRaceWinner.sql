CREATE PROCEDURE [dbo].[usp_UpdateRaceWinner]
	@id int,
	@winner NVARCHAR(200),
	@endedAt DateTime
	--@racers NVARCHAR(4000)
AS
	UPDATE
		[dbo].[Races]
	SET
		[Winner] = @winner, [EndedAt] = @endedAt
	WHERE
		[Id] = @id
