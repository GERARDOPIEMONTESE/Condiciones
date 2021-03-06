/*
   Miércoles, 15 de Diciembre de 201004:15:36 p.m.
   Usuario: sa
   Servidor: 172.17.0.111\ANDROMEDA
   Base de datos: Condiciones
   Aplicación: 
*/

/* Para evitar posibles problemas de pérdida de datos, debe revisar este script detalladamente antes de ejecutarlo fuera del contexto del diseñador de base de datos.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Texto
	DROP CONSTRAINT FK_Texto_TipoTexto
GO
ALTER TABLE dbo.TipoTexto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Texto
	(
	IdTexto int NOT NULL IDENTITY (1, 1),
	Nombre varchar(50) NOT NULL,
	IdTipoTextoResumen int NOT NULL,
	IdTipoTexto int NOT NULL,
	IdUsuario int NOT NULL,
	Fecha datetime NOT NULL,
	IdEstado int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Texto SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Texto ADD CONSTRAINT
	DF_Texto_IdTipoTextoResumen DEFAULT 1 FOR IdTipoTextoResumen
GO
SET IDENTITY_INSERT dbo.Tmp_Texto ON
GO
IF EXISTS(SELECT * FROM dbo.Texto)
	 EXEC('INSERT INTO dbo.Tmp_Texto (IdTexto, Nombre, IdTipoTexto, IdUsuario, Fecha, IdEstado)
		SELECT IdTexto, Nombre, IdTipoTexto, IdUsuario, Fecha, IdEstado FROM dbo.Texto WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Texto OFF
GO
ALTER TABLE dbo.Texto_R_Idioma
	DROP CONSTRAINT FK_TextoResumen_R_Idioma_Texto
GO
DROP TABLE dbo.Texto
GO
EXECUTE sp_rename N'dbo.Tmp_Texto', N'Texto', 'OBJECT' 
GO
ALTER TABLE dbo.Texto ADD CONSTRAINT
	PK_ClausulaTexto PRIMARY KEY CLUSTERED 
	(
	IdTexto
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX Idx_TipoTexto_Estado ON dbo.Texto
	(
	IdTipoTexto,
	IdEstado
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX Idx_TipoTexto_Nombre_Estado ON dbo.Texto
	(
	Nombre,
	IdTipoTexto,
	IdEstado
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.Texto ADD CONSTRAINT
	FK_Texto_TipoTexto FOREIGN KEY
	(
	IdTipoTexto
	) REFERENCES dbo.TipoTexto
	(
	IdTipoTexto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Texto_R_Idioma ADD CONSTRAINT
	FK_TextoResumen_R_Idioma_Texto FOREIGN KEY
	(
	IdTexto
	) REFERENCES dbo.Texto
	(
	IdTexto
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Texto_R_Idioma SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
