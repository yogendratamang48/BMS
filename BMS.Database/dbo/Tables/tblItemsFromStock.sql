CREATE TABLE [dbo].[tblItemsFromStock] (
    [ItemsFromStockID] INT             IDENTITY (1, 1) NOT NULL,
    [ItemID]           INT             NULL,
    [SupplyQuantity]   DECIMAL (18, 2) NULL,
    [Remarks]          NVARCHAR (200)  NULL,
    PRIMARY KEY CLUSTERED ([ItemsFromStockID] ASC),
    CONSTRAINT [FK_tblItemsFromStock_ToTable] FOREIGN KEY ([ItemID]) REFERENCES [dbo].[tblItemInfo] ([ItemID])
);

