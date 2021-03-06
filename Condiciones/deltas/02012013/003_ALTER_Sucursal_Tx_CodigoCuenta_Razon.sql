USE [Portal]
GO
/****** Object:  StoredProcedure [Cuenta].[Sucursal_Tx_CodigoCuenta_RazonSocial_Denominacion]    Script Date: 01/08/2013 12:02:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Yoel Etbul
-- Create date: 04/05/2012
-- Modify By: Matias Badin
-- Modify Date: 08/01/2013
-- =============================================
ALTER PROCEDURE [Cuenta].[Sucursal_Tx_CodigoCuenta_RazonSocial_Denominacion]
	@idLocacion			INT=-1,
	@CodigoCuenta		VARCHAR(5)='',
	@RazonSocial		VARCHAR(100)='',
	@Denominacion		VARCHAR(100)='',
	@IsCondiciones		INT = 0
AS
BEGIN

	IF (@IsCondiciones = 0)
		BEGIN
			SELECT 
				Cuenta.Codigo CodigoCuenta, 
				Sucursal.*, 
				Persona.*, 
				PersonaJuridica.*
			FROM
				Cuenta.Cuenta,
				Cuenta.Sucursal,
				Cuenta.Persona,
				Cuenta.PersonaJuridica
			WHERE
				Cuenta.IdCuenta = Sucursal.IdCuenta
			AND
				Sucursal.IdPersona = Persona.IdPersona
			AND
				Persona.IdPersona = PersonaJuridica.IdPersona
			AND
				((@idLocacion = -1) or (@idLocacion <> -1 and Sucursal.IdLocacion = @idLocacion))
			AND
				((@RazonSocial = '') or (@RazonSocial <> '' and PersonaJuridica.RazonSocial like @RazonSocial + '%'))
			AND
				((@Denominacion = '') or (@Denominacion <> '' and PersonaJuridica.Denominacion like @Denominacion + '%'))
			AND
				((@CodigoCuenta = '') or (@CodigoCuenta <> '' and Cuenta.Codigo = @CodigoCuenta))
		END
	ELSE
		BEGIN
			SELECT C.Codigo as CodigoCuenta, S.*, P.*, PJ.*
			FROM Cuenta.Cuenta C 
			INNER JOIN Cuenta.Sucursal S ON S.IdCuenta = C.IdCuenta
			INNER JOIN Persona P ON P.IdPersona = S.IdPersona
			INNER JOIN PersonaJuridica PJ ON PJ.IdPersona = P.IdPersona
			WHERE 
			((@idLocacion = -1) or (@idLocacion <> -1 and S.IdLocacion = @idLocacion))
			AND ((@RazonSocial = '') or (@RazonSocial <> '' and PJ.RazonSocial like @RazonSocial + '%'))
			AND ((@Denominacion = '') or (@Denominacion <> '' and PJ.Denominacion like @Denominacion + '%'))
			AND ((@CodigoCuenta = '') or (@CodigoCuenta <> '' and C.Codigo = @CodigoCuenta))
			AND S.IdSucursal NOT IN (
				SELECT OAC.IdObjetoAgrupador
				FROM Condiciones.dbo.ObjetoAgrupadorClausula OAC
				INNER JOIN Condiciones.dbo.TipoGrupoClausula TGC ON TGC.IdTipoGrupoClausula = OAC.IdTipoGrupoClausula
				WHERE TGC.Nombre = 'SLA' AND OAC.IdEstado = 25000)
			
		END
END;
