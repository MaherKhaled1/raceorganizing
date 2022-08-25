CREATE PROCEDURE [dbo].[usp_UpdateRacer]
	@id int,
	@name NVARCHAR(200),
	@timeElapsed DateTime
	--@racers NVARCHAR(4000)
AS
	UPDATE
		[dbo].[Racers]
	SET
		[Name] = @name, [TimeElapsed] = @timeElapsed
	Where 
		[Id] = @id
