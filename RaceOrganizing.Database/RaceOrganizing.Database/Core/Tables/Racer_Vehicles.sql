CREATE TABLE [dbo].[Racer_Vehicles]
(
    [Id] INT NOT NULL IDENTITY,
	[RacerId] INT NOT NULL, 
    [VehicleId] INT NOT NULL, 
    CONSTRAINT [FK_Racer_Vehicles_Racers] FOREIGN KEY ([RacerId]) REFERENCES [dbo].[Racers]([Id]), 
    CONSTRAINT [FK_Racer_Vehicles_Vehicles] FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicles]([Id]), 
    CONSTRAINT [PK_Racer_Vehicles] PRIMARY KEY ([RacerId], [VehicleId]),
)
