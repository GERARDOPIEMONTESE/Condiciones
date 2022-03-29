SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 18/01/2011
-- Description:	Modificacion de productos
-- =============================================
CREATE PROCEDURE [dbo].[Producto_M]
	@IdProducto			INT,
	@Codigo						VARCHAR(120),
	@Nombre						VARCHAR(150),
	@IdTipoGrupoClausula		INT,
	@CodigoPais					INT

AS
BEGIN
	UPDATE Producto
	SET
		Codigo = @Codigo,
		Nombre = @Nombre,
		IdTipoGrupoClausula = @IdTipoGrupoClausula,
		CodigoPais = @CodigoPais
	WHERE
		IdProducto = @IdProducto
END
GO
