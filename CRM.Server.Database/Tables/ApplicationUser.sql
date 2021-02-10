CREATE TABLE [dbo].[ApplicationUser](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
	[NormalizedUserName] [nvarchar](256) NOT NULL,
	[FirstName] [nvarchar](256) NOT NULL,
	[LastName] [nvarchar](256) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[MobileNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[CreatedDateTimeUtc] [datetime2](7) NOT NULL,
	[UpdatedDateTimeUtc] [datetime2](7) NOT NULL,
	[Status] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
