USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[ContenidoClausula_Tx_IdGrupoClausula]    Script Date: 01/31/2011 10:24:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 02/03/2010
-- Description:	Busqueda
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausula_Tx_IdGrupoClausula]
	@IdGrupoClausula		INT,
	@IdClausula				INT = 0
AS
BEGIN
	SELECT ContenidoClausula.IdContenidoClausula, ContenidoClausula.IdClausula,
			ContenidoClausula.IdGrupoClausula, ContenidoClausula.IdTipoImpresionClausula,
			ContenidoClausula.IdTipoContenidoImpresion, ContenidoClausula.EvaluableEnAsistencia,
			ContenidoClausula.VisibleEnAsistencia, ContenidoClausula.IdLocacion,
			ContenidoClausula.IdTipoCobertura, 
			(case 
			when ContenidoClausula.Orden > 0 then ContenidoClausula.Orden
			else
				Clausula.OrdenPredefinido
			end) Orden, 
			ContenidoClausula.IdUsuario,
			ContenidoClausula.FechaCreacion, ContenidoClausula.FechaModificacion, ContenidoClausula.IdEstado
	FROM
		ContenidoClausula, Clausula
	WHERE
		ContenidoClausula.IdClausula = Clausula.IdClausula
	AND
		IdGrupoClausula = @IdGrupoClausula
	AND
		(@IdClausula = 0 OR ContenidoClausula.IdClausula = @IdClausula)
	AND
		ContenidoClausula.IdEstado <> 25002
	ORDER BY Orden
END
