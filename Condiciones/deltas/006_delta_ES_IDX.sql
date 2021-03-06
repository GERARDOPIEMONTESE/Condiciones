USE [Condiciones]
GO
CREATE NONCLUSTERED INDEX [Idx_TipoTexto_Estado] ON [dbo].[Texto] 
(
	[IdTipoTexto] ASC,
	[IdEstado] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

USE [Condiciones]
GO
CREATE NONCLUSTERED INDEX [Idx_TipoTexto_Nombre_Estado] ON [dbo].[Texto] 
(
	[Nombre] ASC,
	[IdTipoTexto] ASC,
	[IdEstado] ASC
)WITH (STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
