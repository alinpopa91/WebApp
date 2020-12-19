CREATE TABLE [dbo].[Application_Settings] (
    [Id]          INT             IDENTITY (1, 1) NOT NULL,
    [Key]         NVARCHAR (50)   NULL,
    [Value]       NVARCHAR (500)  NULL,
    [Description] NVARCHAR (4000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

