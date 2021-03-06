USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[Tarifa_A]    Script Date: 11/23/2010 11:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 12/07/2010
-- Description:	Alta producto
-- =============================================
ALTER PROCEDURE [dbo].[Tarifa_A]
	@IdTipoGrupoClausula		INT,
	@IdProducto					INT,
	@CodigoPais					INT,
	@Codigo						VARCHAR(120),
	@Nombre						VARCHAR(150),
	@Sufijo						VARCHAR(20),
	@Anual						BIT = 0,
	@Activa						BIT = 1,
	@IdTipoModalidad			INT = 1
AS
BEGIN
	INSERT INTO
		Tarifa
	(
		IdTipoGrupoClausula,
		IdProducto,
		CodigoPais,
		Codigo,
		Nombre,
		Sufijo,
		Anual,
		Activa,
		IdTipoModalidad
	)
	VALUES
	(
		@IdTipoGrupoClausula,
		@IdProducto,
		@CodigoPais,
		@Codigo,
		@Nombre,
		@Sufijo,
		@Anual,
		@Activa,
		@IdTipoModalidad
	)
	
	RETURN @@IDENTITY
END
