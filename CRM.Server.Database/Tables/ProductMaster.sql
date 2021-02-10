CREATE TABLE [dbo].[ProductMaster](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](250) NULL,
	[Price] [numeric](18, 0) NULL,
	[Status] [varchar](50) NULL,
	[GST] [numeric](18, 0) NULL,
	[HSNCode] [numeric](18, 0) NULL,
 CONSTRAINT [PK_ProductMaster] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
