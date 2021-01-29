CREATE TABLE [dbo].[Ad] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [UserId]         UNIQUEIDENTIFIER NOT NULL,
    [Name]           NVARCHAR (100)   NOT NULL,
    [Description]    NVARCHAR (800)   NULL,
    [YoutubeUrl]     NVARCHAR (1024)  NULL,
    [Keywords]       NVARCHAR (120)   NULL,
    [CreationDate]   DATETIME2 (7)    NOT NULL,
    [DeleteDate]     DATETIME2 (7)    NULL,
    [UpdateDate]     DATETIME2 (7)    NULL,
    [RejectionCount] INT              CONSTRAINT [DF_Ad_RejectionCount] DEFAULT ((0)) NOT NULL,
    [PublishStatus]  INT              NOT NULL,
    [PublishDate]    DATETIME2 (7)    NULL,
    CONSTRAINT [PK_Ad] PRIMARY KEY CLUSTERED ([Id] ASC)
);

