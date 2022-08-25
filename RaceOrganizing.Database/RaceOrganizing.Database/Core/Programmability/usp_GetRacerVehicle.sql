CREATE PROCEDURE [dbo].[usp_GetRacerVehicle]
	@racerId int,
	@vehicleId int

AS
	SELECT

	-- racer info
		racer.[Id] AS Racer_Id, racer.[Name] AS Racer_Name,

	-- vehicle info
		vehicles.[Id] AS Vehicle_Id, vehicles.[BrandName] AS Vehicle_BrandName, vehicles.[VehicleType] AS Vehicle_VehicleType, vehicles.[MaxSpeed] AS Vehicle_MaxSpeed

	FROM [dbo].[Racers] racer 
	JOIN [dbo].[Racer_Vehicles] racervehicles ON racer.Id = racervehicles.RacerId
	JOIN [dbo].[Vehicles] vehicles ON racervehicles.VehicleId = vehicles.Id

	WHERE
		racer.Id = @racerId AND vehicles.Id = @vehicleId