USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Clausula_Tx_BuscarPorParametros]    Script Date: 01/17/2011 17:59:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Clausula_Tx_BuscarPorParametros -1, NULL, NULL
ALTER PROCEDURE [dbo].[Clausula_Tx_BuscarPorParametros]
	@IdTipoClausula		INT = -1,
	@Codigo				VARCHAR(10) = NULL,
	@Nombre				VARCHAR(250) = NULL

AS
BEGIN

	SELECT
		Clausula.IdClausula,
		Clausula.IdTipoClausula,
		Clausula.Codigo,
		Clausula.OrdenPredefinido
	FROM
		Clausula
		INNER JOIN Clausula_R_Idioma
		ON Clausula.IdClausula = Clausula_R_Idioma.IdClausula
	WHERE
	((@IdTipoClausula = -1) OR (@IdTipoClausula <> -1 AND Clausula.IdTipoClausula = @IdTipoClausula))
	AND ((@Codigo IS NULL) OR (@Codigo IS NOT NULL AND Clausula.Codigo LIKE @Codigo + '%'))
	AND (@Nombre IS NULL OR (@Nombre IS NOT NULL AND UPPER(Clausula_R_Idioma.Nombre) like '%' + UPPER(@Nombre) + '%' ))
	AND IdEstado <> 25002
	GROUP BY
		Clausula.IdClausula,
		Clausula.IdTipoClausula,
		Clausula.Codigo,
		Clausula.OrdenPredefinido
	ORDER BY Clausula.Codigo
		
END
