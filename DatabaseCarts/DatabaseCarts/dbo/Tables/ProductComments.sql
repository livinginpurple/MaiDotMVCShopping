CREATE TABLE [dbo].[ProductComments] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     NVARCHAR (MAX) NOT NULL,
    [Content]    NVARCHAR (MAX) NOT NULL,
    [CreateDate] DATETIME       NOT NULL,
    [ProductId]  INT            NOT NULL
);

