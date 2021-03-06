USE [Portal_Prod_Last]
GO
/****** Object:  StoredProcedure [Cuenta].[UsuarioCodigoACNet_Tx_IdCuenta]    Script Date: 09/26/2014 09:51:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Maria de los Angeles Fortelli
-- Create date: 25/09/2014
-- Description:	Buscador de Counters por agencia
-- =============================================
ALTER PROCEDURE [Cuenta].[UsuarioCodigoACNet_Tx_IdCuenta] 
	@IdCuenta		INT
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT 
	us.CorreoElectronico, us.Nombre, us.Apellido,
	net.*, cue.IdCuenta, cue.Codigo, suc.NumeroSucursal, cue.IdLocacion, p.Nombre 
	FROM Cuenta.UsuarioCodigoACNet net
	INNER JOIN Cuenta.Sucursal suc ON net.IdSucursal = suc.IdSucursal
	INNER JOIN Cuenta.Cuenta cue ON suc.IdCuenta = cue.IdCuenta
	INNER JOIN dbo.Usuario us ON net.IdUsuario = us.IdUsuario
	INNER JOIN dbo.Usuario_R_Perfil up ON net.IdUsuario = up.IdUsuario
	INNER JOIN dbo.Perfil p ON up.IdPerfil = p.IdPerfil
	WHERE
		net.IdEstado <> 25002 AND 
		suc.IdEstado <> 25002 AND
		cue.IdEstado <> 25002 AND 
		us.IdEstado <> 25002 AND  
		p.IdEstado <> 25002 AND 
		cue.IdCuenta = @IdCuenta
END
