CREATE TABLE [dbo].[mstCompanyInfo] (
    [CompanyID] INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (200) NULL,
    [Branch]    NVARCHAR (200) NULL,
    [Address]   NVARCHAR (200) NULL,
    [Contact]   NCHAR (20)     NULL,
    [PAN]       NCHAR (20)     NULL,
    [VAT]       NCHAR (20)     NULL,
    [Note]      NVARCHAR (200) NULL,
    PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);

