CREATE TABLE [dbo].[Products] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (100)  NOT NULL,
    [Description]     NVARCHAR (MAX)  NOT NULL,
    [CategoryId]      INT             NOT NULL,
    [Price]           DECIMAL (28, 3) NOT NULL,
    [PublishDate]     DATETIME        NOT NULL,
    [Status]          BIT             NOT NULL,
    [DefaultImageId]  BIGINT          NULL,
    [Quantity]        INT             NOT NULL,
    [DefaultImageURL] NVARCHAR (MAX)  NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED ([Id] ASC)
);

