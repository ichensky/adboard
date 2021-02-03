CREATE TABLE [dbo].[UserProfiles] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (30)    NOT NULL,
    [LastName]    NVARCHAR (30)    NOT NULL,
    [Picture]     NVARCHAR (1024)  NULL,
    [Telegram]    NVARCHAR (50)    NULL,
    [PhoneNumber] NVARCHAR (20)    NULL,
    CONSTRAINT [PK_UserProfiles] PRIMARY KEY CLUSTERED ([Id] ASC),
);





