CREATE DATABASE Karma;
GO

USE Karma;
GO

CREATE TABLE Karma (ID int, KarmaName varchar(max));
GO

/****** Object:  Table [dbo].[EventLogs]    Script Date: 10/20/2021 7:03:06 PM ******/
DROP TABLE IF EXISTS [dbo].[EventLogs]
GO

/****** Object:  Table [dbo].[EventLogs]    Script Date: 10/20/2021 7:03:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EventLogs](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[objectType] [varchar](250) NOT NULL,
	[messageType] [varchar](250) NOT NULL,
	[message] [varchar](1000) NOT NULL,
	[worldDate] [datetime] NULL,
	[realDate] [datetime] NOT NULL,
 CONSTRAINT [PK_EventLogs] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO