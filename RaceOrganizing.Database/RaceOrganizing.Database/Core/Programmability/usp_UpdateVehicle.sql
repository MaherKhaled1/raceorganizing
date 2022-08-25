CREATE PROCEDURE [dbo].[usp_UpdateVehicle]
	@id int,
	@brandName NVARCHAR(200),
	@vehicleType int,
	@maxSpeed int
	--@racers NVARCHAR(4000)
AS
	UPDATE
		[dbo].[Vehicles]
	SET
		[BrandName] = @brandname, [VehicleType] = @vehicleType, [MaxSpeed] = @maxSpeed
	WHERE
		[Id] = @id
