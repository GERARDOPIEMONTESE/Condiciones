USE [Condiciones]
GO

/****** Object:  Table [dbo].[TipoTextoResumen]    Script Date: 12/15/2010 15:58:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TipoTextoResumen](
	[IdTipoTextoResumen] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](10) NOT NULL,
	[Descripcion] [varchar](150) NOT NULL,
 CONSTRAINT [PK_TipoTextoResumen] PRIMARY KEY CLUSTERED 
(
	[IdTipoTextoResumen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

