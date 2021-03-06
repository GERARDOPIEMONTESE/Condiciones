USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[GrupoClausula_Producto_Tx_ModalidadTarifa]    Script Date: 31/01/2018 02:59:33 p.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		daniel.morvallevich
-- Create date: 30/01/2018
-- Description:	Busqueda grupo clausula por producto y por modalidad de la tarifa solicitada
-- =============================================
-- dbo.GrupoClausula_Producto_Tx_ModalidadTarifa
CREATE PROCEDURE [dbo].[GrupoClausula_Producto_Tx_ModalidadTarifa] 
	@IdTipoGrupoClausula	INT = 0,
	@CodigoPais				INT = 0,
	@Anual					BIT = NULL,
	@IdProducto				INT = 0,
	@IdModalidadTarifa		INT = 1,
	@IdEstadoEliminado		INT = 25002
	with recompile
AS
BEGIN
	select g.* from GrupoClausula g where g.IdGrupoClausula in (
	select distinct(oa.IdGrupoClausula) from ObjetoAgrupadorClausula oa where oa.IdObjetoAgrupador in (
		select t.IdTarifa from Tarifa t where t.CodigoPais = @CodigoPais and t.IdTipoGrupoClausula = @IdTipoGrupoClausula and t.IdProducto = @IdProducto and t.Anual = @Anual and (t.Sufijo is null or t.Sufijo = '') and t.IdTipoModalidad = @IdModalidadTarifa
	) 
	and oa.IdEstado <> @IdEstadoEliminado
)
and g.IdEstado <> @IdEstadoEliminado and g.IdTipoGrupoClausula = @IdTipoGrupoClausula and g.Anual = @Anual;

END