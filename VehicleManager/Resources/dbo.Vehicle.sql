CREATE TABLE [dbo].[Vehicle] (
    [ID]          UNIQUEIDENTIFIER        NOT NULL DEFAULT newid(),
    [Owner_First] NCHAR (30) NULL,
    [Owner_Last]  NCHAR (30) NULL,
    [Owner_Phone] NCHAR (30) NULL,
    [Owner_Unit]  NCHAR (30) NULL,
    [Owner_Apt]   NCHAR (30) NULL,
    [Make]        NCHAR (30) NULL,
    [Model]       NCHAR (30) NULL,
    [Color]       NCHAR (30) NULL,
    [CreatedDate] DATE       DEFAULT (getdate()) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);