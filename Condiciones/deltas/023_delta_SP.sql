USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Clausula_M]    Script Date: 01/17/2011 17:48:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 22/04/2010
-- Description:	Modificacion clausula
-- =============================================
ALTER PROCEDURE [dbo].[Clausula_M]
	@IdClausula				INT,
	@IdTipoClausula			INT,
	@Codigo					VARCHAR(10),
	@OrdenPredefinido		INT
AS
BEGIN
	UPDATE 
		Clausula
	SET
		IdTipoClausula = @IdTipoClausula,
		Codigo = @Codigo,
		OrdenPredefinido = @OrdenPredefinido
	WHERE
		IdClausula = @IdClausula
END
