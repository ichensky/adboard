CREATE TABLE [dbo].[AdUsers] (
    [Id]          NVARCHAR (450)  NOT NULL,
    [FirstName]   NVARCHAR (50)   NOT NULL,
    [SecondName]  NVARCHAR (50)   NOT NULL,
    [Telegram]    NVARCHAR (50)   NULL,
    [PhoneNumber] NVARCHAR (20)   NULL,
    [Picture]     NVARCHAR (1024) NULL,
    CONSTRAINT [PK_AdUsers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AdUsers_AspNetUsers] FOREIGN KEY ([Id]) REFERENCES [dbo].[AspNetUsers] ([Id])
);



