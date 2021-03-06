USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Producto_Tx_CodigoPais]    Script Date: 10/19/2011 12:42:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joaquin
-- Create date: 19/10/2011
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
	ORDER BY Producto.Nombre;
END
