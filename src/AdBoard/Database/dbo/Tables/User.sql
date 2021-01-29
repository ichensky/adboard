CREATE TABLE [dbo].[User] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [FirstName]   NVARCHAR (30)    NOT NULL,
    [SecondName]  NVARCHAR (30)    NOT NULL,
    [PhoneNumber] NCHAR (30)       NULL,
    [Telegram]    NCHAR (50)       NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

