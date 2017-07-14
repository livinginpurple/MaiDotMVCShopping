CREATE TABLE [dbo].[Orders] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [UserId]          NVARCHAR (MAX) NOT NULL,
    [ReceiverName]    NVARCHAR (MAX) NOT NULL,
    [ReceiverPhone]   NVARCHAR (MAX) NOT NULL,
    [ReceiverAddress] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([Id] ASC)
);

