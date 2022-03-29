USE [Condiciones]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Matis Badin
-- Create date: 11/01/2013
-- Description:	Busqueda grupo clausulas SLA
-- =============================================
CREATE PROCEDURE dbo.GrupoClausula_Tx_AgenciaSucursal
	@CodigoPais				INT,
	@IdTipoGrupoClausula	INT,
	@CodigoAgencia			NVARCHAR(5),
	@NumeroSucursal			INT
AS
BEGIN
	SELECT DISTINCT GC.*
	FROM Portal.Cuenta.Cuenta C
	INNER JOIN Portal.Cuenta.Sucursal S ON C.IdCuenta = S.IdCuenta
	INNER JOIN Portal.Locacion.Pais P ON P.IdLocacion = S.IdLocacion
	INNER JOIN ObjetoAgrupadorClausula OAC ON OAC.IdObjetoAgrupador = S.IdSucursal
	INNER JOIN GrupoClausula GC ON OAC.IdGrupoClausula = GC.IdGrupoClausula
	WHERE 
		P.Codigo = @CodigoPais
	AND	OAC.IdTipoGrupoClausula = @IdTipoGrupoClausula
	AND C.Codigo = @CodigoAgencia
	AND S.NumeroSucursal = @NumeroSucursal
	AND C.IdEstado <> 25002 AND OAC.IdEstado <> 25002
	AND GC.IdEstado <> 25002 AND S.IdEstado <> 25002
END



	
	