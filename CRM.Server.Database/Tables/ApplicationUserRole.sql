CREATE TABLE [dbo].[ApplicationUserRole](
	[UserId] [bigint] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ApplicationUserRole]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[ApplicationRole] ([Id])
GO

ALTER TABLE [dbo].[ApplicationUserRole] CHECK CONSTRAINT [FK_ApplicationUserRole_Role]
GO

ALTER TABLE [dbo].[ApplicationUserRole]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationUserRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[ApplicationUser] ([Id])
GO

ALTER TABLE [dbo].[ApplicationUserRole] CHECK CONSTRAINT [FK_ApplicationUserRole_User]
GO
