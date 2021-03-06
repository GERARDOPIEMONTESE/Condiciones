/*
   Lunes, 17 de Enero de 201105:43:26 p.m.
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
ALTER TABLE dbo.Clausula
	DROP CONSTRAINT FK_Clausula_TipoClausula
GO
ALTER TABLE dbo.TipoClausula SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Clausula
	(
	IdClausula int NOT NULL IDENTITY (1, 1),
	IdTipoClausula int NOT NULL,
	Codigo varchar(10) NOT NULL,
	OrdenPredefinido int NOT NULL,
	IdUsuario int NOT NULL,
	Fecha datetime NOT NULL,
	IdEstado int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Clausula SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Clausula ADD CONSTRAINT
	DF_Clausula_OrdenPredefinido DEFAULT 0 FOR OrdenPredefinido
GO
SET IDENTITY_INSERT dbo.Tmp_Clausula ON
GO
IF EXISTS(SELECT * FROM dbo.Clausula)
	 EXEC('INSERT INTO dbo.Tmp_Clausula (IdClausula, IdTipoClausula, Codigo, IdUsuario, Fecha, IdEstado)
		SELECT IdClausula, IdTipoClausula, Codigo, IdUsuario, Fecha, IdEstado FROM dbo.Clausula WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Clausula OFF
GO
ALTER TABLE dbo.Clausula_R_Idioma
	DROP CONSTRAINT FK_Clausula_R_Idioma_Clausula
GO
ALTER TABLE dbo.ContenidoClausula
	DROP CONSTRAINT FK_ContenidoClausula_Clausula
GO
DROP TABLE dbo.Clausula
GO
EXECUTE sp_rename N'dbo.Tmp_Clausula', N'Clausula', 'OBJECT' 
GO
ALTER TABLE dbo.Clausula ADD CONSTRAINT
	PK_Clausula PRIMARY KEY CLUSTERED 
	(
	IdClausula
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Clausula ADD CONSTRAINT
	FK_Clausula_TipoClausula FOREIGN KEY
	(
	IdTipoClausula
	) REFERENCES dbo.TipoClausula
	(
	IdTipoClausula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.ContenidoClausula ADD CONSTRAINT
	FK_ContenidoClausula_Clausula FOREIGN KEY
	(
	IdClausula
	) REFERENCES dbo.Clausula
	(
	IdClausula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.ContenidoClausula SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Clausula_R_Idioma ADD CONSTRAINT
	FK_Clausula_R_Idioma_Clausula FOREIGN KEY
	(
	IdClausula
	) REFERENCES dbo.Clausula
	(
	IdClausula
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Clausula_R_Idioma SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
