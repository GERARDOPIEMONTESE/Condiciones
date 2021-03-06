USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[GrupoClausula_Tarifa_Tx_Producto]    Script Date: 11/23/2010 15:13:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 08/07/2010
-- Description:	Busqueda de grupo clausula y tarifa
-- =============================================
-- dbo.GrupoClausula_Tarifa_Tx_Producto 1, 540, 4439, '', ''
ALTER PROCEDURE [dbo].[GrupoClausula_Tarifa_Tx_Producto]
	@IdTipoGrupoClausula	INT = 0,
	@CodigoPais				INT = 0,
	@Anual					BIT = NULL,
	@IdProducto				INT = 0,
	@CodigoProducto			VARCHAR(20) = '',
	@Sufijo					VARCHAR(20) = '',
	@CodigoTarifa			VARCHAR(20) = '',
	@IdEstadoEliminado		INT = 25002
AS
BEGIN
	SELECT DISTINCT GrupoClausula.IdGrupoClausula Id, TipoGrupoClausula.Nombre NombreTipoGrupoClausula,
		Locacion.Nombre NombreLocacion, 
		'' NombreTextoResumen, 
		Producto.Nombre + ' (' + Producto.Codigo + ')' Producto,
		'' Tarifa, isnull(Tarifa.Sufijo, '_') Sufijo, Tarifa.Anual, TipoModalidad.Descripcion TipoModalidad	
	FROM
		GrupoClausula, ObjetoAgrupadorClausula, 
		TipoGrupoClausula,
		Tarifa, Producto,
		TipoModalidad,
		Portal.Locacion.Locacion,
		Portal.Locacion.Pais
	WHERE
		GrupoClausula.IdGrupoClausula = ObjetoAgrupadorClausula.IdGrupoClausula
	AND
		GrupoClausula.IdTipoGrupoClausula = ObjetoAgrupadorClausula.IdTipoGrupoClausula
	AND
		ObjetoAgrupadorClausula.IdObjetoAgrupador = Tarifa.IdTarifa
	AND
		ObjetoAgrupadorClausula.IdTipoGrupoClausula = Tarifa.IdTipoGrupoClausula
	AND
		GrupoClausula.IdTipoGrupoClausula = TipoGrupoClausula.IdTipoGrupoClausula
	AND
		Tarifa.IdProducto = Producto.IdProducto
	AND
		Locacion.IdLocacion = Pais.IdLocacion
	AND
		Tarifa.CodigoPais = Pais.Codigo
	AND
		Tarifa.IdTipoModalidad = TipoModalidad.IdTipoModalidad
	AND
		GrupoClausula.IdEstado <> @IdEstadoEliminado
	AND
		ObjetoAgrupadorClausula.IdEstado <> @IdEstadoEliminado
	AND
		(@IdTipoGrupoClausula = 0 OR GrupoClausula.IdTipoGrupoClausula = @IdTipoGrupoClausula)
	AND
		(@CodigoPais = 0 OR Pais.Codigo = @CodigoPais)
	AND
		(@Anual IS NULL OR GrupoClausula.Anual = @Anual)
	AND
		(@IdProducto = 0 OR Producto.IdProducto = @IdProducto)
	AND
		(@CodigoProducto = '' OR Producto.Codigo = @CodigoProducto)
	AND
		(@Sufijo = '' OR Tarifa.Sufijo = @Sufijo)
	AND
		(@CodigoTarifa = '' OR Tarifa.Codigo = @CodigoTarifa)
	ORDER BY 
		NombreTipoGrupoClausula, NombreLocacion, Producto, Tarifa, Sufijo		
END
/*ALTER PROCEDURE [dbo].[GrupoClausula_Tarifa_Tx_Producto]
	@IdTipoGrupoClausula	INT = 0,
	@CodigoPais				INT = 0,
	@Anual					BIT = NULL,
	@IdProducto				INT = 0,
	@CodigoProducto			VARCHAR(20) = '',
	@Sufijo					VARCHAR(20) = '',
	@CodigoTarifa			VARCHAR(20) = '',
	@IdEstadoEliminado		INT = 25002
AS
BEGIN
/*	SELECT GrupoClausula.IdGrupoClausula Id, TipoGrupoClausula.Nombre NombreTipoGrupoClausula,
		Locacion.Nombre NombreLocacion, 
		ISNULL((SELECT Nombre FROM Texto WHERE IdTipoTexto = 1 
			AND IdTexto = GrupoClausula.IdTextoResumen), '_') NombreTextoResumen, 
		Producto.Nombre + ' (' + Producto.Codigo + ')' Producto,
		Tarifa.Nombre + ' (' + Tarifa.Codigo + ')' Tarifa, isnull(Tarifa.Sufijo, '_') Sufijo*/
	SELECT DISTINCT GrupoClausula.IdGrupoClausula Id, TipoGrupoClausula.Nombre NombreTipoGrupoClausula,
		Locacion.Nombre NombreLocacion, 
		'' NombreTextoResumen, 
		Producto.Nombre + ' (' + Producto.Codigo + ')' Producto,
		'' Tarifa, isnull(Tarifa.Sufijo, '_') Sufijo, Tarifa.Anual		
	FROM
		GrupoClausula, ObjetoAgrupadorClausula, 
		TipoGrupoClausula,
		Tarifa, Producto,
		Portal.Locacion.Locacion,
		Portal.Locacion.Pais
	WHERE
		GrupoClausula.IdGrupoClausula = ObjetoAgrupadorClausula.IdGrupoClausula
	AND
		GrupoClausula.IdTipoGrupoClausula = ObjetoAgrupadorClausula.IdTipoGrupoClausula
	AND
		ObjetoAgrupadorClausula.IdObjetoAgrupador = Tarifa.IdTarifa
	AND
		ObjetoAgrupadorClausula.IdTipoGrupoClausula = Tarifa.IdTipoGrupoClausula
	AND
		GrupoClausula.IdTipoGrupoClausula = TipoGrupoClausula.IdTipoGrupoClausula
	AND
		Tarifa.IdProducto = Producto.IdProducto
	AND
		Locacion.IdLocacion = Pais.IdLocacion
	AND
		Tarifa.CodigoPais = Pais.Codigo
	AND
		GrupoClausula.IdEstado <> @IdEstadoEliminado
	AND
		ObjetoAgrupadorClausula.IdEstado <> @IdEstadoEliminado
	AND
		(@IdTipoGrupoClausula = 0 OR GrupoClausula.IdTipoGrupoClausula = @IdTipoGrupoClausula)
	AND
		(@CodigoPais = 0 OR Pais.Codigo = @CodigoPais)
	AND
		(@Anual IS NULL OR GrupoClausula.Anual = @Anual)
	AND
		(@IdProducto = 0 OR Producto.IdProducto = @IdProducto)
	AND
		(@CodigoProducto = '' OR Producto.Codigo = @CodigoProducto)
	AND
		(@Sufijo = '' OR Tarifa.Sufijo = @Sufijo)
	AND
		(@CodigoTarifa = '' OR Tarifa.Codigo = @CodigoTarifa)
	ORDER BY 
		NombreTipoGrupoClausula, NombreLocacion, Producto, Tarifa, Sufijo		
END
*/
select distinct IdTipoModalidad from ContenidoClausulaRango