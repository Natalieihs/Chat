USE [Chat]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12/18/2018 20:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[RoomID] [int] NOT NULL,
	[AddTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'消息内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'Content'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送人id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送人名字' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属房间id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'RoomID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Messages', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
/****** Object:  Table [dbo].[ChatRooms]    Script Date: 12/18/2018 20:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatRooms](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](20) NOT NULL,
	[Describe] [nvarchar](50) NOT NULL,
	[MemberCount] [int] NOT NULL,
	[AdminID] [int] NOT NULL,
	[AdminName] [nvarchar](50) NOT NULL,
	[AddTime] [datetime] NOT NULL,
	[IsEnable] [bit] NOT NULL,
 CONSTRAINT [PK_ChatRooms] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房间名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'RoomName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'Describe'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'成员数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'MemberCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'AdminID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理员名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'AdminName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'AddTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否启用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatRooms', @level2type=N'COLUMN',@level2name=N'IsEnable'
GO
/****** Object:  Table [dbo].[ChatMembers]    Script Date: 12/18/2018 20:06:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMembers](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserName] [nvarchar](20) NOT NULL,
	[NickName] [nvarchar](50) NOT NULL,
	[RoomID] [int] NOT NULL,
	[IsOnline] [bit] NOT NULL,
	[LastOnlineTime] [datetime] NOT NULL,
 CONSTRAINT [PK_ChatMembers] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'ID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'UserID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'UserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户昵称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'NickName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'房间ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'RoomID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否在线' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'IsOnline'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后在线时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ChatMembers', @level2type=N'COLUMN',@level2name=N'LastOnlineTime'
GO
