CREATE PROCEDURE [dbo].[usp_GetAllRaces]

AS
	SELECT
		r.[Id] AS Race_Id, r.[Name] AS Race_Name, r.[Distance] AS Race_Distance,
		r.[VehicleType] AS Race_VehicleType, r.Winner As Race_Winner, r.EndedAt As Race_EndedAt
	FROM
		[dbo].[Races] r
