USE [CBOPortal]
GO

/****** Object:  Table [dbo].[NewWinsDetails]    Script Date: 27-Aug-18 03:58:27 PM ******/

CREATE TABLE [dbo].[NewWinsDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[ProjectDescription] [varchar](100) NULL,
	[StartDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[ContactEmail] [varchar](50) NOT NULL,
 CONSTRAINT [PK_NewWinsDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[PipelineDetails]    Script Date: 27-Aug-18 03:59:37 PM ******/
CREATE TABLE [dbo].[PipelineDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[ProjectDescription] [varchar](100) NULL,
	[ExpectedStartDate] [date] NOT NULL,
	[ContactName] [varchar](50) NOT NULL,
	[ContactEmail] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PipelineDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[CBOUpdatesDetails]    Script Date: 27-Aug-18 04:00:31 PM ******/


CREATE TABLE [dbo].[CBOUpdatesDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[Document] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CBOUpdatesDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[AlertDetails]    Script Date: 27-Aug-18 04:01:30 PM ******/

CREATE TABLE [dbo].[AlertDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[Document] [varchar](100) NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AlertDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Table [dbo].[SpotLightDetails]    Script Date: 27-Aug-18 04:02:18 PM ******/

CREATE TABLE [dbo].[SpotLightDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[ProjectName] [varchar](50) NOT NULL,
	[EmployeeName] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[EmployeeEmailId] [varchar](50) NOT NULL,
	[Month] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SpotLightDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


/****** Object:  Table [dbo].[EventDetails]    Script Date: 27-Aug-18 04:02:50 PM ******/

CREATE TABLE [dbo].[EventDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](50) NOT NULL,
	[Description] [varchar](100) NULL,
	[Frequency] [varchar](50) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsMobileDisplay] [bit] NULL,
	[Document] [varchar](100) NULL,
	[CreatedDate] [date] NOT NULL,
	[CreatedBy] [varchar](50) NOT NULL,
	[UpdatedDate] [date] NOT NULL,
	[UpdatedBy] [varchar](50) NOT NULL,
 CONSTRAINT [PK_EventDetails] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
