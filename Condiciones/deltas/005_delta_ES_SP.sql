SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 25/11/2010
-- Description:	Busqueda textos por parametros
-- =============================================
CREATE PROCEDURE [dbo].[Texto_R_Idioma_Parametros]
	@Nombre				VARCHAR(50) = NULL,
	@IdIdioma			INT = 0,
	@IdTipoTexto		INT,
	@IdEstadoEliminado	INT = 25002
AS
BEGIN
	SELECT * FROM
		Texto, Texto_R_Idioma
	WHERE
		Texto.IdTexto = Texto_R_Idioma.IdTexto
	AND
		Texto.IdEstado <> @IdEstadoEliminado
	AND
		Texto.IdTipoTexto = @IdTipoTexto
	AND
		(@Nombre IS NULL OR Texto.Nombre LIKE '%' + @Nombre + '%')
	AND
		(@IdIdioma = 0 OR Texto_R_Idioma.IdIdioma = @IdIdioma)
END
GO
