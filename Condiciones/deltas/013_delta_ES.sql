/*
   Miércoles, 15 de Diciembre de 201005:13:34 p.m.
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
CREATE TABLE dbo.Tmp_Texto_L
	(
	IdTexto_L int NOT NULL IDENTITY (1, 1),
	IdTexto int NOT NULL,
	Nombre varchar(50) NOT NULL,
	IdTipoTexto int NOT NULL,
	IdTipoTextoResumen int NOT NULL,
	IdUsuario int NOT NULL,
	Fecha datetime NOT NULL,
	FechaAlta datetime NOT NULL,
	IdEstado int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Texto_L SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_Texto_L ADD CONSTRAINT
	DF_Texto_L_IdTipoTextoResumen DEFAULT 1 FOR IdTipoTextoResumen
GO
SET IDENTITY_INSERT dbo.Tmp_Texto_L ON
GO
IF EXISTS(SELECT * FROM dbo.Texto_L)
	 EXEC('INSERT INTO dbo.Tmp_Texto_L (IdTexto_L, IdTexto, Nombre, IdTipoTexto, IdUsuario, Fecha, FechaAlta, IdEstado)
		SELECT IdTexto_L, IdTexto, Nombre, IdTipoTexto, IdUsuario, Fecha, FechaAlta, IdEstado FROM dbo.Texto_L WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Texto_L OFF
GO
DROP TABLE dbo.Texto_L
GO
EXECUTE sp_rename N'dbo.Tmp_Texto_L', N'Texto_L', 'OBJECT' 
GO
ALTER TABLE dbo.Texto_L ADD CONSTRAINT
	PK_Texto_L PRIMARY KEY CLUSTERED 
	(
	IdTexto_L
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
