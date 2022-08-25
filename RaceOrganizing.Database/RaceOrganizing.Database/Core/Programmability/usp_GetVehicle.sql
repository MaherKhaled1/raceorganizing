CREATE PROCEDURE [dbo].[usp_GetVehicle]
	@id int

AS
	SELECT
		v.[Id] AS Vehicle_Id, v.[BrandName] AS Vehicle_BrandName, v.[VehicleType] AS Vehicle_VehicleType, v.[MaxSpeed] AS Vehicle_MaxSpeed 
	FROM
		[dbo].[Vehicles] v
	WHERE
		[Id] = @id