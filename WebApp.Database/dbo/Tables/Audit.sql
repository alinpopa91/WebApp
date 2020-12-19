CREATE TABLE [dbo].[Audit] (
    [ID]          UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [UserAgent]   NVARCHAR (600)   NULL,
    [IPAddress]   NVARCHAR (50)    NULL,
    [UrlRequired] NVARCHAR (1000)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

