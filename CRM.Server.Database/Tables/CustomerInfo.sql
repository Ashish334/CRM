CREATE TABLE [dbo].[CustomerInfo]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(250) NULL, 
    [Domain] BIGINT NULL, 
    [EmailId] VARCHAR(250) NULL, 
    [ShopName] VARCHAR(250) NULL, 
    [MobileNo] NUMERIC NULL, 
    [Address1] VARCHAR(500) NULL, 
    [Address2] VARCHAR(500) NULL, 
    [Address3] VARCHAR(500) NULL, 
    [City] VARCHAR(250) NULL, 
    [District] VARCHAR(250) NULL, 
    [State] VARCHAR(250) NULL, 
    [PinCode] VARCHAR(250) NULL, 
    [Status] INT NULL, 
    [ProductInterested] VARCHAR(250) NULL, 
    [LeadType] VARCHAR(250) NULL, 
    [BusinessType] VARCHAR(250) NULL
)
