CREATE TABLE [dbo].[ArtDirectory] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (150) NULL,
    [Description] TEXT           NULL,
    [Category]    INT            NULL,
    [Visible]     INT            NULL,
    [Price]       DECIMAL (18)   NULL,
    [Size]        NCHAR (1)      NULL,
    [Original]    NVARCHAR (10)  NULL,
    [Signed]      BIT            NULL,
    [Code]        NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

