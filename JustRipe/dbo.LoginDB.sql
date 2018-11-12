CREATE TABLE [dbo].[LoginDB]
(
	[Id] INT    IDENTITY (1, 1) NOT NULL,
    [username] VARCHAR(50) NULL, 
    [password] VARCHAR(100) NULL, 
    [permissions] VARCHAR(20) NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC)
);
