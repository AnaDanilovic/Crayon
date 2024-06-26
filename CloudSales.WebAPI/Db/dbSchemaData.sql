
USE [Crayon]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 5/3/2024 6:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[AccountId] [bigint] IDENTITY(1,1) NOT NULL,
	[AccountName] [nvarchar](50) NOT NULL,
	[UserId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK__Account] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Log]    Script Date: 5/3/2024 6:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogId] [bigint] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](500) NOT NULL,
	[StackTrace] [nvarchar](2000) NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchasedSoftware]    Script Date: 5/3/2024 6:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchasedSoftware](
	[PurchasedSoftwareId] [bigint] IDENTITY(1,1) NOT NULL,
	[SoftwareId] [bigint] NOT NULL,
	[SoftwareName] [nvarchar](200) NOT NULL,
	[Quantity] [int] NOT NULL,
	[State] [bit] NOT NULL,
	[ValidToDate] [datetime] NOT NULL,
	[AccountId] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK__PurchasedSoftware] PRIMARY KEY CLUSTERED 
(
	[PurchasedSoftwareId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/3/2024 6:49:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
 CONSTRAINT [PK__User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (1, N'Ana Office account', 2, CAST(N'2024-05-03T16:39:21.713' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (2, N'Ana Design account', 2, CAST(N'2024-05-03T16:39:21.727' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (3, N'Ana AI account', 2, CAST(N'2024-05-03T16:39:21.727' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (4, N'Crayon user Office account', 1, CAST(N'2024-05-03T16:39:21.727' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (5, N'Crayon user Design account', 1, CAST(N'2024-05-03T16:39:21.730' AS DateTime), NULL)
INSERT [dbo].[Account] ([AccountId], [AccountName], [UserId], [DateCreated], [DateUpdated]) VALUES (6, N'Crayon user AI account', 1, CAST(N'2024-05-03T16:39:21.730' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[Log] ON 

INSERT [dbo].[Log] ([LogId], [Message], [StackTrace], [DateCreated]) VALUES (1, N'Licence not found', N'   at CloudSales.DataLayer.Repositories.PurchasedSoftwareRepository.UpdateLicenceQuantity(Int64 accountId, Int64 softwareId, Int32 licenceCount) in C:\Users\ana.danilovic\Documents\Ana\CrayonCloudSales\CloudSales.DataLayer\Repositories\PurchasedSoftwareRepository.cs:line 74
   at CloudSales.WebAPI.Controllers.PurchasedSoftwareController.Post(Int64 accountId, Int64 softwareId, Int32 quantity) in C:\Users\ana.danilovic\Documents\Ana\CrayonCloudSales\CloudSales.WebAPI\Controllers\PurchasedSoftwareController.cs:line 108', CAST(N'2024-05-03T16:20:11.893' AS DateTime))
SET IDENTITY_INSERT [dbo].[Log] OFF
GO
SET IDENTITY_INSERT [dbo].[PurchasedSoftware] ON 

INSERT [dbo].[PurchasedSoftware] ([PurchasedSoftwareId], [SoftwareId], [SoftwareName], [Quantity], [State], [ValidToDate], [AccountId], [DateCreated], [DateUpdated]) VALUES (1, 1, N'Microsoft Office', 1, 1, CAST(N'2024-08-09T00:00:00.000' AS DateTime), 4, CAST(N'2024-05-03T15:44:34.487' AS DateTime), CAST(N'2024-05-03T15:57:12.863' AS DateTime))
INSERT [dbo].[PurchasedSoftware] ([PurchasedSoftwareId], [SoftwareId], [SoftwareName], [Quantity], [State], [ValidToDate], [AccountId], [DateCreated], [DateUpdated]) VALUES (2, 6, N'Adobe Photoshop', 5, 1, CAST(N'2024-06-02T16:19:59.880' AS DateTime), 4, CAST(N'2024-05-03T16:19:59.880' AS DateTime), NULL)
INSERT [dbo].[PurchasedSoftware] ([PurchasedSoftwareId], [SoftwareId], [SoftwareName], [Quantity], [State], [ValidToDate], [AccountId], [DateCreated], [DateUpdated]) VALUES (3, 1, N'Microsoft Office', 3, 1, CAST(N'2024-06-02T16:28:22.463' AS DateTime), 3, CAST(N'2024-05-03T16:28:22.463' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[PurchasedSoftware] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserId], [Username], [Email], [DateCreated], [DateUpdated]) VALUES (1, N'crayon.user', N'crayon.user@email.com', CAST(N'2024-05-03T16:36:49.550' AS DateTime), NULL)
INSERT [dbo].[User] ([UserId], [Username], [Email], [DateCreated], [DateUpdated]) VALUES (2, N'anad', N'ana.danilovic@email.com', CAST(N'2024-05-03T16:37:06.030' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_User]
GO
ALTER TABLE [dbo].[PurchasedSoftware]  WITH CHECK ADD  CONSTRAINT [FK_PurchasedSoftware_Account] FOREIGN KEY([AccountId])
REFERENCES [dbo].[Account] ([AccountId])
GO
ALTER TABLE [dbo].[PurchasedSoftware] CHECK CONSTRAINT [FK_PurchasedSoftware_Account]
GO
