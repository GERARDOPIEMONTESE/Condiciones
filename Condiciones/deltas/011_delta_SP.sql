SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 15/12/2010
-- Description:	Busqueda tipo texto resumen por id
-- =============================================
CREATE PROCEDURE [dbo].[TipoTextoResumen_Tx_IdTipoTextoResumen]
	@IdTipoTextoResumen			INT
AS
BEGIN
	SELECT *
	FROM
		TipoTextoResumen
	WHERE
		IdTipoTextoResumen = @IdTipoTextoResumen
END
GO
