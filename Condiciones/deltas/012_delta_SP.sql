SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 15/12/2010
-- Description:	Busqueda tipo texto resumen por id
-- =============================================
CREATE PROCEDURE [dbo].[TipoTextoResumen_Tx_Codigo]
	@Codigo				VARCHAR(10) = NULL
AS
BEGIN
	SELECT *
	FROM
		TipoTextoResumen
	WHERE
		@Codigo IS NULL OR Codigo = @Codigo
END
GO
