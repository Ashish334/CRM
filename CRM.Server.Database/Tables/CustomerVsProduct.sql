CREATE TABLE [dbo].[CustomerVsProduct](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[indexId] [int] NULL,
	[CustomerId] [int] NULL,
	[CustomerName] [varchar](250) NULL,
	[ProductName] [varchar](250) NULL,
	[Price] [numeric](18, 2) NULL,
	[Qty] [bigint] NULL,
	[DiscountPer] [bigint] NULL,
	[DiscountAmt] [numeric](18, 2) NULL,
	[GstPer] [bigint] NULL,
	[GstAmt] [numeric](18, 2) NULL,
	[NetAmount] [numeric](18, 2) NULL,
 CONSTRAINT [PK_CustomerVsProduct] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

