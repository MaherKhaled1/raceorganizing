CREATE PROCEDURE [dbo].[usp_GetRacer]
	@id int

AS
	SELECT
		r.[Id] AS Racer_Id, r.[Name] AS Racer_Name, r.[TimeElapsed] AS Racer_TimeElapsed
	FROM
		[dbo].[Racers] r
	WHERE
		[Id] = @id