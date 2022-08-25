CREATE PROCEDURE [dbo].[usp_CreateVehicle]
	@brandName NVARCHAR(200),
	@vehicleType int,
	@maxSpeed int
	--@racers NVARCHAR(4000)
AS
	INSERT INTO [dbo].[Vehicles]
		([BrandName], [VehicleType], [MaxSpeed])
	VALUES
		(@brandName, @vehicleType, @maxSpeed)

	SELECT CAST(@@IDENTITY AS INT)
