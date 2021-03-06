USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Clausula_A]    Script Date: 01/17/2011 17:45:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Clausula_A]
	@IdTipoClausula		INT,
	@Codigo				VARCHAR(10),
	@OrdenPredefinido	INT,
	@IdUsuario			INT,
	@Fecha				DATETIME,
	@IdEstado			INT
AS
BEGIN
	
	INSERT INTO	
		Clausula
		(
			IdTipoClausula,
			Codigo,
			OrdenPredefinido,
			IdUsuario,
			Fecha,
			IdEstado
		)			
	VALUES
		(
		@IdTipoClausula,
		@Codigo,
		@OrdenPredefinido,
		@IdUsuario,
		@Fecha,
		@IdEstado
		);
		
	RETURN(@@IDENTITY);


END
