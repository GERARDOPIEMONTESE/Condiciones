/*
   Lunes, 17 de Enero de 201105:44:49 p.m.
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
CREATE TABLE dbo.Tmp_Clausula_L
	(
	IdClausula_L int NOT NULL IDENTITY (1, 1),
	IdClausula int NOT NULL,
	IdTipoClausula int NOT NULL,
	Codigo varchar(10) NOT NULL,
	OrdenPredefinido int NOT NULL,
	IdUsuario int NOT NULL,
	Fecha datetime NOT NULL,
	IdEstado int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Clausula_L SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Clausula_L ADD CONSTRAINT
	DF_Clausula_L_OrdenPredefinido DEFAULT 0 FOR OrdenPredefinido
GO
SET IDENTITY_INSERT dbo.Tmp_Clausula_L ON
GO
IF EXISTS(SELECT * FROM dbo.Clausula_L)
	 EXEC('INSERT INTO dbo.Tmp_Clausula_L (IdClausula_L, IdClausula, IdTipoClausula, Codigo, IdUsuario, Fecha, IdEstado)
		SELECT IdClausula_L, IdClausula, IdTipoClausula, Codigo, IdUsuario, Fecha, IdEstado FROM dbo.Clausula_L WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Clausula_L OFF
GO
DROP TABLE dbo.Clausula_L
GO
EXECUTE sp_rename N'dbo.Tmp_Clausula_L', N'Clausula_L', 'OBJECT' 
GO
ALTER TABLE dbo.Clausula_L ADD CONSTRAINT
	PK_Clausula_L PRIMARY KEY CLUSTERED 
	(
	IdClausula_L
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
