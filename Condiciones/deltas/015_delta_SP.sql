USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Texto_A]    Script Date: 12/15/2010 17:14:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Texto_A]
	@Nombre					VARCHAR(50),
	@IdTipoTexto			INT,
	@IdTipoTextoResumen		INT,
	@IdUsuario				INT,
	@Fecha					DATETIME,
	@IdEstado				INT
AS
BEGIN
	
	INSERT INTO	
		Texto
		(Nombre, IdTipoTextoResumen, IdTipoTexto, IdUsuario, Fecha, IdEstado)
	VALUES
		(
		@Nombre,
		@IdTipoTextoResumen,
		@IdTipoTexto,
		@IdUsuario,
		@Fecha,
		@IdEstado
		);
		
	RETURN(@@IDENTITY);


END
