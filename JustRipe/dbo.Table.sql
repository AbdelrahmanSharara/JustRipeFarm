CREATE TABLE [dbo].[LoginDB]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] VARCHAR(MAX) NULL, 
    [password] VARCHAR(MAX) NULL, 
    [permissions] VARCHAR(MAX) NULL
)
