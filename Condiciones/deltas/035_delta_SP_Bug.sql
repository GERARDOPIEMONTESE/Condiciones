USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Documento_M]    Script Date: 09/12/2013 11:49:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 23/03/2010
-- Description:	Baja documento
-- =============================================
ALTER PROCEDURE [dbo].[Documento_M]
	@IdDocumento			INT,
	@IdTipoDocumento		INT,
	@Nombre					VARCHAR(50),
	@Documento				IMAGE,
	@DocumentoDimension		INT,
	@DocumentoTipoContenido	VARCHAR(50),
	@Observaciones			VARCHAR(500),
	@IdIdioma				INT,
	@IdUsuario				INT = 0
AS
BEGIN
	UPDATE
		Documento
	SET
		IdTipoDocumento = @IdTipoDocumento,
		Nombre = @Nombre,
		Documento = @Documento,
		DocumentoDimension = @DocumentoDimension,
		DocumentoTipoContenido = @DocumentoTipoContenido,
		Observaciones = @Observaciones,
		IdIdioma = @IdIdioma,
		IdUsuario = @IdUsuario
	WHERE
		IdDocumento = @IdDocumento
END
