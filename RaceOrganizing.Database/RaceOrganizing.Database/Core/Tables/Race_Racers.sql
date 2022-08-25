CREATE TABLE [dbo].[Race_Racers]
(
    [Id] INT NOT NULL IDENTITY,
    [RaceId] INT NOT NULL, 
    [RacerId] INT NOT NULL, 
    CONSTRAINT [FK_Race_Racers_Races] FOREIGN KEY ([RaceId]) REFERENCES [dbo].[Races]([Id]), 
    CONSTRAINT [FK_Race_Racers_Racers] FOREIGN KEY ([RacerId]) REFERENCES [dbo].[Racers]([Id]), 
    CONSTRAINT [PK_Race_Racers] PRIMARY KEY ([RaceId], [RacerId]),
)
