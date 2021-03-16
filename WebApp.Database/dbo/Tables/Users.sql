CREATE TABLE [dbo].[Users] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (50)  NOT NULL,
    [Name]        NVARCHAR (100) NULL,
    [Email]       NVARCHAR (100) NULL,
    [Password]    CHAR (32)      NULL,
    [Role]        NVARCHAR (30)  NULL,
    [DateOfBirth] DATE           NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);



