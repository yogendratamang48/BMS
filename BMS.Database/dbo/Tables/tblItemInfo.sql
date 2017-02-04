CREATE TABLE [dbo].[tblItemInfo] (
    [ItemID]      INT             IDENTITY (1, 1) NOT NULL,
    [ReqID]       INT             NULL,
    [KhataNumber] NCHAR (20)      NULL,
    [ItemName]    NVARCHAR (200)  NULL,
    [Quantity]    DECIMAL (18, 2) NULL,
    [Unit]        DECIMAL (18, 2) NULL,
    [Remarks]     NVARCHAR (200)  NULL,
    PRIMARY KEY CLUSTERED ([ItemID] ASC),
    CONSTRAINT [FK_tblItemInfo_ToReq] FOREIGN KEY ([ReqID]) REFERENCES [dbo].[tblRequisitionForm] ([ReqID])
);

