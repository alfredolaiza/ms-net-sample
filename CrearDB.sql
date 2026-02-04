
CREATE TABLE [dbo].[TodoItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ListId] [int] NULL,
	[Title] [varchar](max) NULL,
	[Note] [varchar](max) NULL,
	[Priority] [int] NULL,
	[Done] [bit] NULL,
	[Created] [datetimeoffset](7) NULL,
	[Reminder] [datetime2](7) NULL,
	[CreatedBy] [varchar](max) NULL,
	[LastModified] [datetimeoffset](7) NULL,
	[LastModifiedBy] [varchar](max) NULL,
 CONSTRAINT [PK_TodoItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[TodoLists](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](max) NULL,
	[Colour_Code] [varchar](max) NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [varchar](max) NULL,
	[LastModified] [datetimeoffset](7) NULL,
	[LastModifiedBy] [varchar](max) NULL,
 CONSTRAINT [PK_TodoLists] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO



CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](max) NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [varchar](max) NULL,
	[LastModified] [datetimeoffset](7) NULL,
	[LastModifiedBy] [varchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];
GO

/* Añadir tabla producto */
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[Description] [varchar](max) NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[Stock] [int] NOT NULL,
	[Created] [datetimeoffset](7) NULL,
	[CreatedBy] [varchar](max) NULL,
	[LastModified] [datetimeoffset](7) NULL,
	[LastModifiedBy] [varchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];