﻿CREATE TABLE [dbo].[Racers]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
    [TimeElapsed] DATETIME NOT NULL,
)
