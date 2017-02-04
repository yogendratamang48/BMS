CREATE TABLE [dbo].[tblStock] (
    [StockID]       INT             IDENTITY (1, 1) NOT NULL,
    [ReqID]         INT             NULL,
    [RequestState]  NVARCHAR (50)   NULL,
    [ItemName]      NVARCHAR (200)  NULL,
    [Quantity]      DECIMAL (18, 2) NULL,
    [Unit]          DECIMAL (18, 2) NULL,
    [Remarks]       NVARCHAR (200)  NULL,
    [RespondedDate] DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([StockID] ASC),
    CONSTRAINT [FK_tblStock_ToReq] FOREIGN KEY ([ReqID]) REFERENCES [dbo].[tblRequisitionForm] ([ReqID])
);

