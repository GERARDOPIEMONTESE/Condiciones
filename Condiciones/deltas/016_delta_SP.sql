USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Texto_M]    Script Date: 12/15/2010 17:16:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 05/04/2010
-- Description:	Modificacion texto
-- =============================================
ALTER PROCEDURE [dbo].[Texto_M]
    @IdTexto				INT,
	@Nombre					VARCHAR(50),
	@IdTipoTexto			INT,
	@IdTipoTextoResumen		INT
AS
BEGIN
	UPDATE
		Texto
	SET
		Nombre = @Nombre,
		IdTipoTexto = @IdTipoTexto,
		IdTipoTextoResumen = @IdTipoTextoResumen
	WHERE
		IdTexto = @IdTexto
END
