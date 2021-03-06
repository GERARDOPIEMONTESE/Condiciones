USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Tarifa_M]    Script Date: 11/23/2010 11:37:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 21/09/2010
-- Description:	Modificacion tarifa
-- =============================================
ALTER PROCEDURE [dbo].[Tarifa_M]
	@IdTarifa					INT,
	@Nombre						VARCHAR(150),
	@Sufijo						VARCHAR(20),
	@Activa						BIT = 1,
	@IdTipoModalidad			INT = 1
AS
BEGIN
	UPDATE 
		Tarifa
	SET
		Nombre = @Nombre ,
		Sufijo = @Sufijo,
		Activa = @Activa,
		IdtipoModalidad = @IdTipoModalidad
	WHERE
		IdTarifa = @IdTarifa
END
