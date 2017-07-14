CREATE TABLE [dbo].[OrderDetails] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [OrderId]  INT            NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Price]    DECIMAL (18)   NOT NULL,
    [Quantity] INT            NOT NULL,
    CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_OrderOrderDetail] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Orders] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_OrderOrderDetail]
    ON [dbo].[OrderDetails]([OrderId] ASC);

