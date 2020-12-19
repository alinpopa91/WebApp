CREATE TABLE [dbo].[Users] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (500) NULL,
    [LastName]  NVARCHAR (500) NULL,
    [IsEnabled] BIT            DEFAULT ((0)) NOT NULL,
    [RoleId]    INT            NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

