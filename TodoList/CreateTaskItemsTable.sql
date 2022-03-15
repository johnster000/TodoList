CREATE TABLE [dbo].[TaskItems] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Description]   NVARCHAR (500) NOT NULL,
    [DateAdded]     DATETIME       NOT NULL,
    [DateCompleted] DATETIME       NULL,
    [Status_ID]     INT            NOT NULL
);