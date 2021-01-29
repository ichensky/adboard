CREATE TABLE [dbo].[Pictures] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [AdsId]        UNIQUEIDENTIFIER NOT NULL,
    [Description]  NVARCHAR (128)   NULL,
    [Order]        INT              CONSTRAINT [DF_Picture_Order] DEFAULT ((0)) NOT NULL,
    [CreationDate] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Pictures] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Pictures_Ads] FOREIGN KEY ([AdsId]) REFERENCES [dbo].[Ads] ([Id])
);

