CREATE TABLE [dbo].[CustomerMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[Domain] [varchar](150) NULL,
	[Email] [varchar](50) NULL,
	[ShopName] [varchar](250) NULL,
	[Mobile] [numeric](18, 0) NULL,
	[Address1] [varchar](250) NULL,
	[Address2] [varchar](250) NULL,
	[Address3] [varchar](250) NULL,
	[District] [varchar](150) NULL,
	[City] [varchar](150) NULL,
	[State] [varchar](250) NULL,
	[PinCode] [numeric](18, 0) NOT NULL,
	[Status] [varchar](150) NULL,
	[InterestedProduct] [varchar](150) NOT NULL,
	[LeadType] [varchar](150) NOT NULL,
	[BusinessType] [varchar](150) NOT NULL,
	[ReferenceName] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
