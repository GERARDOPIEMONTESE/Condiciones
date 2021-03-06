USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Clausula_L_A]    Script Date: 01/17/2011 17:48:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 15/04/2010
-- Description:	Alta log clausula
-- =============================================
ALTER PROCEDURE [dbo].[Clausula_L_A]
	@IdClausula				INT,
	@IdTipoClausula			INT,
	@Codigo					VARCHAR(10),
	@OrdenPredefinido		INT,
	@IdUsuario				INT,
	@Fecha					DATETIME,
	@IdEstado				INT
AS
BEGIN
	INSERT INTO
		Clausula_L
	(
		IdClausula,
		IdTipoClausula,
		Codigo,
		OrdenPredefinido,
		IdUsuario,
		Fecha,
		IdEstado
	)
	VALUES
	(
		@IdClausula,
		@IdTipoClausula,
		@Codigo,
		@OrdenPredefinido,
		@IdUsuario,
		@Fecha,
		@IdEstado
	);
	
	RETURN @@IDENTITY
END
