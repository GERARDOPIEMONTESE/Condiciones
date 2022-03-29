USE [Condiciones]
GO

/****** Object:  StoredProcedure [dbo].[GrupoClausula_SLA_Tx_AgenciaSucursal]    Script Date: 01/04/2013 15:23:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:        Matias Badin
-- Create date:   03/01/2013
-- Description:   Busqueda de grupo clausula SLA
-- =============================================

CREATE PROCEDURE [dbo].[GrupoClausula_SLA_Tx_AgenciaSucursal]
      @IdTipoGrupoClausula         INT,
      @CodigoPais                  INT = 0,
      @Agencia					   NVARCHAR(5) = NULL,
      @Sucursal                    INT = -1
AS
BEGIN

      SELECT DISTINCT GC.IdGrupoClausula Id, 
      L.Nombre NombreLocacion,
      C.Codigo Agencia, S.NumeroSucursal Sucursal 
      
      FROM Portal.Cuenta.Cuenta C
      INNER JOIN Portal.Cuenta.Sucursal S on S.IdCuenta = C.IdCuenta
      INNER JOIN Portal.Locacion.Locacion L on L.IdLocacion = C.IdLocacion
      INNER JOIN Portal.Locacion.Pais P on P.IdLocacion = L.IdLocacion
      INNER JOIN ObjetoAgrupadorClausula OAC on OAC.IdObjetoAgrupador = S.IdSucursal
      INNER JOIN GrupoClausula GC on OAC.IdGrupoClausula = GC.IdGrupoClausula
      WHERE
		      (@CodigoPais = 0 OR P.Codigo = @CodigoPais)
		  AND (@Agencia IS NULL OR (@Agencia IS NOT NULL AND C.Codigo LIKE @Agencia))
          AND (@Sucursal = -1 OR S.NumeroSucursal = @Sucursal)
          AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002 and C.IdEstado <> 25002
      ORDER BY 
            NombreLocacion, Agencia, Sucursal           
END



GO


