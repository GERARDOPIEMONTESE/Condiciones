USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Texto_L_A]    Script Date: 12/15/2010 17:14:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 15/04/2010
-- Description:	Alta log clausula
-- =============================================
ALTER PROCEDURE [dbo].[Texto_L_A]
	@IdTexto				INT,
	@Nombre					VARCHAR(50),
	@IdTipoTexto			INT,
	@IdTipoTextoResumen		INT,
	@IdUsuario				INT,
	@Fecha					DATETIME,
	@IdEstado				INT
AS
BEGIN
	INSERT INTO
		Texto_L
	(
		IdTexto,
		Nombre,
		IdTipoTexto,
		IdTipoTextoResumen,
		IdUsuario,
		Fecha,
		FechaAlta,
		IdEstado
	)
	VALUES
	(
		@IdTexto,
		@Nombre,
		@IdTipoTexto,
		@IdTipoTextoResumen,
		@IdUsuario,
		@Fecha,
		GETDATE(),
		@IdEstado
	);
	
	RETURN @@IDENTITY
END
