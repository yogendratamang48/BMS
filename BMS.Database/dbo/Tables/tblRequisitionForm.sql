CREATE TABLE [dbo].[tblRequisitionForm] (
    [ReqID]         INT            IDENTITY (1, 1) NOT NULL,
    [CompanyID]     INT            NULL,
    [EmployeeName]  NVARCHAR (200) NULL,
    [Purpose]       NVARCHAR (200) NULL,
    [RequestedDate] DATETIME       NULL,
    [CreatedBy]     NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([ReqID] ASC),
    CONSTRAINT [FK_tblRequisitionForm_ToCompanyInfo] FOREIGN KEY ([CompanyID]) REFERENCES [dbo].[mstCompanyInfo] ([CompanyID])
);

