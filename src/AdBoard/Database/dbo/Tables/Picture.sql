CREATE TABLE [dbo].[Picture] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [AdId]         UNIQUEIDENTIFIER NOT NULL,
    [Description]  NVARCHAR (128)   NULL,
    [Order]        INT              CONSTRAINT [DF_Picture_Order] DEFAULT ((0)) NOT NULL,
    [CreationDate] DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_Picture] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Picture_Picture] FOREIGN KEY ([AdId]) REFERENCES [dbo].[Ad] ([Id])
);

