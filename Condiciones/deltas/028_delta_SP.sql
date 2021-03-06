USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Producto_Tx_CodigoPais]    Script Date: 02/03/2011 09:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 25-02-2010
-- Description:	Busqueda de productos por pais
-- =============================================
ALTER PROCEDURE [dbo].[Producto_Tx_CodigoPais]
	@CodigoPais				INT,
	@IdTipoGrupoClausula	INT = 0
AS
BEGIN
	SELECT *
	FROM
		dbo.Producto
	WHERE
		CodigoPais = @CodigoPais
	AND
		(@IdTipoGrupoClausula = 0 OR IdTipoGrupoClausula = @IdTipoGrupoClausula)
	ORDER BY Producto.Codigo;
END
