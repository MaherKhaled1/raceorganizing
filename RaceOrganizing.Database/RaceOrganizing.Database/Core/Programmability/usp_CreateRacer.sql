CREATE PROCEDURE [dbo].[usp_CreateRacer]
	@name NVARCHAR(200),
	@timeElapsed DateTime
	--@racers NVARCHAR(4000)
AS
	INSERT INTO [dbo].[Racers]
		([Name], [TimeElapsed])
	VALUES
		(@name, @timeElapsed)
	SELECT CAST(@@IDENTITY AS INT)
