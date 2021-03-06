/*
   Miércoles, 15 de Diciembre de 201004:18:13 p.m.
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
ALTER TABLE dbo.TipoTextoResumen SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Texto ADD CONSTRAINT
	FK_Texto_TipoTextoResumen FOREIGN KEY
	(
	IdTipoTextoResumen
	) REFERENCES dbo.TipoTextoResumen
	(
	IdTipoTextoResumen
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Texto SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
