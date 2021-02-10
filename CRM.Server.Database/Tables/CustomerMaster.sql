CREATE TABLE [dbo].[CustomerMaster]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [Name] VARCHAR(150) NOT NULL, 
    [Domain] VARCHAR(150) NULL, 
    [Email] VARCHAR(50) NULL, 
    [ShopName] VARCHAR(250) NULL, 
    [Mobile] NUMERIC NULL, 
    [Address1] VARCHAR(250) NULL, 
    [Address2] VARCHAR(250) NULL, 
    [Address3] VARCHAR(250) NULL, 
    [District] VARCHAR(150) NULL, 
    [City] VARCHAR(150) NULL, 
    [State] VARCHAR(250) NULL, 
    [PinCode] NUMERIC NOT NULL, 
    [Status] VARCHAR(150) NULL, 
    [InterestedProduct] VARCHAR(150) NOT NULL, 
    [LeadType] VARCHAR(150) NOT NULL, 
    [BusinessType] VARCHAR(150) NOT NULL, 
    [ReferenceName] VARCHAR(150) NULL
)
