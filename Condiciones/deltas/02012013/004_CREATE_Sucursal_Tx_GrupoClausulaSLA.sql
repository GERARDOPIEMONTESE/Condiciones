-- =============================================
-- Author:		Matias Badin
-- Create date: 08/01/2013
-- =============================================
CREATE PROCEDURE [Cuenta].[Sucursal_Tx_GrupoClausulaSLA]
	@IdLocacion				INT = -1,
	@IdGrupo				INT,
	@IdTipoGrupoClausula	INT
AS
BEGIN

	SELECT C.Codigo AS CodigoCuenta, S.*
	FROM Cuenta.Sucursal S 
	INNER JOIN Cuenta.Cuenta C ON C.IdCuenta = S.IdCuenta
	INNER JOIN Condiciones.dbo.ObjetoAgrupadorClausula OAC ON S.IdSucursal = OAC.IdObjetoAgrupador
	WHERE
		OAC.IdGrupoClausula = @IdGrupo 
		AND (@IdLocacion = -1 OR (@IdLocacion <> -1 AND S.IdLocacion = @IdLocacion))
		AND OAC.IdEstado <> 25002 AND S.IdEstado <> 25002 AND C.IdEstado <> 25002
END
