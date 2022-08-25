CREATE TABLE [dbo].[Vehicles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[BrandName] NVARCHAR(200) NOT NULL,
    [VehicleType] INT NOT NULL,  
    [MaxSpeed] INT NOT NULL,
)
