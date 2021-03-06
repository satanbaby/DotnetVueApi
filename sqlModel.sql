USE [homeworkDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Admins]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admins](
	[Account] [nvarchar](450) NOT NULL,
	[Password] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admins] PRIMARY KEY CLUSTERED 
(
	[Account] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Members]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Members](
	[UId] [nvarchar](450) NOT NULL,
	[UPwd] [nvarchar](max) NULL,
	[UName] [nvarchar](max) NULL,
	[RegisterTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[UId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OId] [nvarchar](450) NOT NULL,
	[orderQty] [int] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[MembersUId] [nvarchar](450) NULL,
	[PruductIDPId] [nvarchar](450) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pruducts]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pruducts](
	[PId] [nvarchar](450) NOT NULL,
	[PName] [nvarchar](max) NULL,
	[Price] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_Pruducts] PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20181212153012_init', N'2.1.1-rtm-30846')
INSERT [dbo].[Members] ([UId], [UPwd], [UName], [RegisterTime]) VALUES (N'user001', N'user001', N'蔡英文', CAST(N'2018-12-13T00:18:10.0877893' AS DateTime2))
INSERT [dbo].[Members] ([UId], [UPwd], [UName], [RegisterTime]) VALUES (N'user002', N'user002', N'柯文哲', CAST(N'2018-12-12T23:42:44.6349623' AS DateTime2))
INSERT [dbo].[Members] ([UId], [UPwd], [UName], [RegisterTime]) VALUES (N'user003', N'user003', N'李新', CAST(N'2018-12-12T23:52:14.9872303' AS DateTime2))
INSERT [dbo].[Members] ([UId], [UPwd], [UName], [RegisterTime]) VALUES (N'user004', N'user004', N'葛特曼', CAST(N'2018-12-12T23:53:12.7924322' AS DateTime2))
INSERT [dbo].[Members] ([UId], [UPwd], [UName], [RegisterTime]) VALUES (N'user005', N'user005', N'習近平', CAST(N'2018-12-13T00:18:10.0000000' AS DateTime2))
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'20181217021538', 1, CAST(N'2018-12-17T02:15:39.0806548' AS DateTime2), N'user002', N'P0001')
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'20181218010315', 1, CAST(N'2018-12-18T01:03:15.6175135' AS DateTime2), N'user002', N'P0001')
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'20181218011053', 1, CAST(N'2018-12-18T01:10:53.2836424' AS DateTime2), N'user002', N'p0003')
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'O001', 3, CAST(N'2018-12-13T00:18:10.0877893' AS DateTime2), N'user003', N'P0002')
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'O002', 2, CAST(N'2016-12-11T00:00:00.0000000' AS DateTime2), N'user001', N'P0001')
INSERT [dbo].[Orders] ([OId], [orderQty], [CreateTime], [MembersUId], [PruductIDPId]) VALUES (N'O003', 4, CAST(N'2018-12-12T00:00:00.0000000' AS DateTime2), N'user001', N'P0002')
INSERT [dbo].[Pruducts] ([PId], [PName], [Price], [Qty]) VALUES (N'P0001', N'愛滋器捐', 10000, 10)
INSERT [dbo].[Pruducts] ([PId], [PName], [Price], [Qty]) VALUES (N'P0002', N'MG149', 390, 10)
INSERT [dbo].[Pruducts] ([PId], [PName], [Price], [Qty]) VALUES (N'p0003', N'重陽敬老金', 1500, 14999)
INSERT [dbo].[Pruducts] ([PId], [PName], [Price], [Qty]) VALUES (N'P0004', N'台北大巨蛋', 5000, 3)
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Members_MembersUId] FOREIGN KEY([MembersUId])
REFERENCES [dbo].[Members] ([UId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Members_MembersUId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Pruducts_PruductIDPId] FOREIGN KEY([PruductIDPId])
REFERENCES [dbo].[Pruducts] ([PId])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Pruducts_PruductIDPId]
GO
/****** Object:  StoredProcedure [dbo].[addOrder]    Script Date: 2018/12/30 上午 12:43:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addOrder]
	@id		nvarchar(450),
	@qty	int,
	@member nvarchar(450),
	@pruduct nvarchar(450),
	@time	datetime2(7)
AS

BEGIN
	insert into Orders(OId,PruductIDPId,orderQty,MembersUId,CreateTime)
	values		  (@id,@pruduct,	@qty,	@member,	@time)
END
GO
