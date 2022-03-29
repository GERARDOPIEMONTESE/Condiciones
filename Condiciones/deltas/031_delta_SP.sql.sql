USE [Condiciones]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Print 'Inicio del proceso'
GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda asociacion
-- =============================================
ALTER PROCEDURE [dbo].[AsociacionContenidoClausula_Tx_IdContenidoClausula]
	@IdContenidoClausulaHijo	INT = 0,
	@IdContenidoClausulaPadre	INT = 0
AS
BEGIN
	SELECT A.*,
		 Cl.Codigo CodigoClausulaPadre,
		 Cl.IdClausula IdClausulaPadre
	FROM AsociacionContenidoClausula A 
	INNER JOIN ContenidoClausula C ON C.IdContenidoClausula =  A.IdContenidoClausulaPadre
	INNER JOIN Clausula Cl ON Cl.IdClausula = C.IdClausula
	WHERE (@IdContenidoClausulaHijo = 0 OR IdContenidoClausulaHijo = @IdContenidoClausulaHijo)
		AND	(@IdContenidoClausulaPadre = 0 OR IdContenidoClausulaPadre = @IdContenidoClausulaPadre)
	
END

GO



-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[AsociacionContenidoClausulaGrupoMasiva_E]
	@IdGrupoClausula				INT,
	@IdEstadoBorrado				INT = 25002
AS
BEGIN
	DELETE FROM
		AsociacionContenidoClausula
	WHERE
		IdContenidoClausulaHijo IN (
			SELECT DISTINCT IdGrupoClausula 
			FROM ContenidoClausula 
			WHERE IdGrupoClausula = @IdGrupoClausula)
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 06/05/2010
-- Description:	Obtener Asociaciones de un documento determinado
-- =============================================
ALTER PROCEDURE [dbo].[AsociacionDocumento_Tx_IdDocumento]
	@IdDocumento					INT = 0,
	@IdTipoAsociacionDocumento		INT = 0,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	SELECT *
	FROM
		AsociacionDocumento
	WHERE
		IdDocumento = @IdDocumento
		AND (@IdTipoAsociacionDocumento = 0 OR IdTipoAsociacionDocumento = @IdTipoAsociacionDocumento)
		AND IdEstado <> @IdEstadoEliminado
	ORDER BY IdTipoAsociacionDocumento, IdObjeto		
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda
-- =============================================
ALTER PROCEDURE [dbo].[AsociacionDocumento_Tx_IdObjeto]
	@IdTipoAsociacionDocumento		INT = 0,
	@IdObjeto						INT = 0,
	@IdTipoDocumento				INT = 0,
	@IdEstado						INT = 25002
AS
BEGIN
	SELECT *
	FROM AsociacionDocumento A
	INNER JOIN Documento D ON D.IdDocumento = A.IdDocumento AND D.IdEstado <> @IdEstado AND A.IdEstado <> @IdEstado
	AND (@IdTipoAsociacionDocumento = 0 OR IdTipoAsociacionDocumento = @IdTipoAsociacionDocumento)
	AND (@IdObjeto = 0 OR IdObjeto = @IdObjeto)	
	AND (@IdTipoDocumento = 0 OR D.IdTipoDocumento = @IdTipoDocumento)
END

GO
-- =============================================
-- Author:		Joaquin de las heras
-- Create date: 26/09/2011
-- Description:	Busqueda Asociaciones
-- =============================================
-- AsociacionDocumento_Tx_IdTipoAsociacionDocumento 0
ALTER PROCEDURE [dbo].[AsociacionDocumento_Tx_IdTipoAsociacionDocumento]
	@IdTipoAsociacionDocumento		INT = 0,
	@IdEstadoEliminado				INT, 
	@IdExcluyeTipoAsociacion		INT
AS
BEGIN
	SELECT *
	FROM
		AsociacionDocumento
	WHERE (@IdTipoAsociacionDocumento = 0 OR IdTipoAsociacionDocumento = @IdTipoAsociacionDocumento)
		AND	IdEstado <> @IdEstadoEliminado
		AND	IdTipoAsociacionDocumento <> @IdExcluyeTipoAsociacion
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[AsociacionDocumentoMasiva_E]
	@IdGrupoClausula				INT,
	@IdEstadoBorrado				INT = 25002
AS
BEGIN
	UPDATE AsociacionDocumento
	SET	IdEstado = @IdEstadoBorrado
	WHERE IdObjeto = @IdGrupoClausula
		AND IdEstado <> @IdEstadoBorrado
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busca por Parametros
-- =============================================
ALTER PROCEDURE [dbo].[Clausula_Tx_BuscarPorParametros]
	@IdTipoClausula		INT = -1,
	@Codigo				VARCHAR(10) = NULL,
	@Nombre				VARCHAR(250) = NULL,
	@IdEstadoEliminado INT = 25002

AS
BEGIN

	SELECT
		Clausula.IdClausula,
		Clausula.IdTipoClausula,
		Clausula.Codigo,
		Clausula.OrdenPredefinido
	FROM Clausula
	INNER JOIN Clausula_R_Idioma ON Clausula.IdClausula = Clausula_R_Idioma.IdClausula
	WHERE
		((@IdTipoClausula = -1) OR (@IdTipoClausula <> -1 AND Clausula.IdTipoClausula = @IdTipoClausula))
		AND ((@Codigo IS NULL) OR (@Codigo IS NOT NULL AND Clausula.Codigo LIKE @Codigo + '%'))
		AND (@Nombre IS NULL OR (@Nombre IS NOT NULL AND Clausula_R_Idioma.Nombre like '%' + @Nombre + '%' ))
		AND IdEstado <> @IdEstadoEliminado
	GROUP BY
		Clausula.IdClausula,
		Clausula.IdTipoClausula,
		Clausula.Codigo,
		Clausula.OrdenPredefinido
	ORDER BY Clausula.Codigo
		
END
GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda clausula por codigo
-- =============================================
ALTER PROCEDURE [dbo].[Clausula_Tx_Codigo]
	@Codigo				VARCHAR(10) = NULL,
	@IdEstadoEliminado  INT = 25002
AS
BEGIN
	SELECT *
	FROM  dbo.Clausula
	WHERE @Codigo IS NULL OR Codigo = @Codigo
		AND IdEstado <> @IdEstadoEliminado
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 30/03/2010
-- Description:	Modificacion leyenda contenido clausula
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausula_M_Leyenda]
	@IdGrupoClausula		INT,
	@IdClausula				INT,
	@IdIdioma				INT,
	@Texto					VARCHAR(500),
	@IdEstadoEliminado		INT =25002
AS
BEGIN
	UPDATE dbo.Leyenda
	SET Texto = @Texto
	WHERE IdEstado <> @IdEstadoEliminado
	AND IdIdioma = @IdIdioma
	AND Leyenda.IdContenidoClausulaRango IN (
			SELECT IdContenidoClausulaRango
			FROM ContenidoClausula C
			INNER JOIN ContenidoClausulaRango R ON R.IdContenidoClausula = C.IdContenidoClausula
				WHERE IdClausula = @IdClausula
				AND IdGrupoClausula = @IdGrupoClausula
				AND C.IdEstado <> @IdEstadoEliminado)
END


GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausula_Tx_IdGrupoClausula]
	@IdGrupoClausula		INT,
	@IdClausula				INT = 0,
	@IdEstadoEliminado		INT = 25002
AS
BEGIN
	SELECT 
			ContenidoClausula.IdContenidoClausula,
			ContenidoClausula.IdClausula,
			ContenidoClausula.IdGrupoClausula,
			ContenidoClausula.IdTipoImpresionClausula,
			ContenidoClausula.IdTipoContenidoImpresion, 
			ContenidoClausula.EvaluableEnAsistencia,
			ContenidoClausula.VisibleEnAsistencia, 
			ContenidoClausula.IdLocacion,
			ContenidoClausula.IdTipoCobertura, 
			(case 
				when ContenidoClausula.Orden > 0 then ContenidoClausula.Orden 
				else Clausula.OrdenPredefinido 
			end) Orden, 
			ContenidoClausula.IdUsuario,
			ContenidoClausula.FechaCreacion,
			ContenidoClausula.FechaModificacion,
			ContenidoClausula.IdEstado
	FROM
		ContenidoClausula
	INNER JOIN Clausula Clausula ON ContenidoClausula.IdClausula = Clausula.IdClausula
	WHERE IdGrupoClausula = @IdGrupoClausula
	AND	(@IdClausula = 0 OR ContenidoClausula.IdClausula = @IdClausula)
	AND	ContenidoClausula.IdEstado <> @IdEstadoEliminado
	ORDER BY Orden
END

GO
-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaMasiva_E]
	@IdGrupoClausula				INT,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	UPDATE ContenidoClausula
	SET IdEstado = @IdEstadoEliminado
	WHERE IdGrupoClausula = @IdGrupoClausula
	AND IdEstado <> @IdEstadoEliminado
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Modificacion Contenido de rango
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaRango_M_Contenido]
@IdGrupoClausula		INT,
@IdClausula				INT,
@EdadMinima				INT = -1,
@EdadMaxima				INT = -1,
@IdTipoPlan				INT = -1,
@IdTipoModalidad		INT = -1,
@Categoria				INT = -1,
@IdEstadoEliminado		INT = 25002,
@Contenido				VARCHAR(500)
AS
BEGIN
	UPDATE dbo.ContenidoClausulaRango
	SET Contenido = @Contenido
	WHERE IdEstado <> @IdEstadoEliminado
	AND (@EdadMinima = -1 OR EdadMinima = @EdadMinima)
	AND (@EdadMaxima = -1 OR EdadMaxima = @EdadMaxima)
	AND (@IdTipoPlan = -1 OR IdTipoPlan = @IdTipoPlan)
	AND	(@IdTipoModalidad = -1 OR IdTipoModalidad = @IdTipoModalidad)
	AND	(@Categoria = -1 OR Categoria = @Categoria)
	AND	IdContenidoClausula IN (
			SELECT IdContenidoClausula
			FROM dbo.ContenidoClausula Contenido
			WHERE Contenido.IdEstado <> @IdEstadoEliminado
			AND Contenido.IdGrupoClausula = @IdGrupoClausula
			AND	Contenido.IdClausula = @IdClausula)
END

GO

-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 17/03/2010
-- Description:	Busqueda rangos
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaRango_Tx_Edad]
	@IdContenidoClausula			INT,
	@Edad							INT = -1,
	@IdTipoPlan						INT = 0,
	@IdTipoModalidad				INT = 0,
	@Categoria						INT = -1,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	SELECT *
	FROM dbo.ContenidoClausulaRango Rango
	WHERE Rango.IdEstado <> @IdEstadoEliminado
	AND	Rango.IdContenidoClausula = @IdContenidoClausula
	AND	(@Edad = -1 OR Rango.EdadMinima = 0 OR Rango.EdadMinima <= @Edad)
	AND	(@Edad = -1 OR Rango.EdadMaxima = 0 OR Rango.EdadMaxima >= @Edad)
	AND	(@IdTipoModalidad = 0 OR Rango.IdTipoModalidad = 1 OR Rango.IdTipoModalidad = @IdTipoModalidad)
	AND (@Categoria = -1 OR Rango.Categoria = @Categoria)
	AND	(@IdTipoPlan = 0 OR Rango.IdTipoPlan = 1 OR Rango.IdTipoPlan = @IdTipoPlan)
END

GO
-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda contenido clausula por rango
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaRango_Tx_IdContenidoClausula] 
	@IdContenidoClausula		INT,
	@IdEstadoEliminado			INT =25002
AS
BEGIN
	SELECT *
	FROM ContenidoClausulaRango
	WHERE IdContenidoClausula = @IdContenidoClausula
		AND IdEstado <> @IdEstadoEliminado
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaRangoMasiva_E]
	@IdContenidoClausula			INT,
	@IdEstadoBorrado				INT = 25002
AS
BEGIN
	UPDATE ContenidoClausulaRango
	SET	IdEstado = @IdEstadoBorrado
	WHERE IdContenidoClausula = @IdContenidoClausula
		AND	IdEstado <> @IdEstadoBorrado
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[ContenidoClausulaRangoMasivaGrupo_E]
	@IdGrupoClausula				INT,
	@IdEstadoBorrado				INT = 25002
AS
BEGIN
	UPDATE ContenidoClausulaRango
	SET IdEstado = @IdEstadoBorrado
	WHERE  IdEstado <> @IdEstadoBorrado
	AND IdContenidoClausula IN (
			SELECT DISTINCT IdGrupoClausula 
			FROM ContenidoClausula 
			WHERE IdGrupoClausula = @IdGrupoClausula)
	
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Alta relacion texto y grupo
-- =============================================
ALTER PROCEDURE [dbo].[GrupoClausula_R_Texto_Masiva_E]
	@IdGrupoClausula		 INT,
	@IdEstadoBorrado		 INT =25002
AS
BEGIN
	UPDATE GrupoClausula_R_Texto
		SET IdEstado = @IdEstadoBorrado
	WHERE IdGrupoClausula = @IdGrupoClausula
		AND IdEstado <> @IdEstadoBorrado
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Existe grupo clausula por clausula
-- =============================================
ALTER PROCEDURE [dbo].[GrupoClausula_Tx_IdClausula]
	@IdClausula				INT,
	@IdEstadoEliminado		INT = 25002
AS
BEGIN
	SELECT *
	FROM ContenidoClausula
	WHERE IdClausula = @IdClausula
	AND IdEstado <> @IdEstadoEliminado
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda grupos por documentos
-- =============================================
ALTER PROCEDURE [dbo].[GrupoClausula_Tx_IdDocumento]
	@IdDocumento					INT,
	@IdTipoAsociacionDocumento		INT,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	SELECT *
	FROM AsociacionDocumento 
	INNER JOIN 	GrupoClausula ON AsociacionDocumento.IdObjeto = GrupoClausula.IdGrupoClausula
		AND	AsociacionDocumento.IdEstado <> @IdEstadoEliminado
		AND	AsociacionDocumento.IdTipoAsociacionDocumento = @IdTipoAsociacionDocumento
		AND GrupoClausula.IdEstado <> @IdEstadoEliminado
	INNER JOIN Documento ON Documento.IdDocumento = AsociacionDocumento.IdDocumento
		AND Documento.IdEstado <> @IdEstadoEliminado
		
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda grupo por tarifa
-- =============================================
ALTER PROCEDURE [dbo].[GrupoClausula_Tx_IdTarifa]
	@IdTipoGrupoClausula		INT,
	@IdTarifa					INT,
	@IdEstadoEliminado			INT = 25002
AS
BEGIN
	SELECT *
	FROM GrupoClausula Grupo
	INNER JOIN ObjetoAgrupadorClausula Objeto ON  Objeto.IdObjetoAgrupador = @IdTarifa AND Objeto.IdGrupoClausula = Grupo.IdGrupoClausula
	WHERE Grupo.IdEstado <> @IdEstadoEliminado
	AND	Objeto.IdEstado <> @IdEstadoEliminado
	AND	Grupo.IdTipoGrupoClausula = @IdTipoGrupoClausula
	AND	Objeto.IdTipoGrupoClausula = @IdTipoGrupoClausula
	
		
END


GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda grupo clausula
-- =============================================
-- dbo.GrupoClausula_Tx_Producto
ALTER PROCEDURE [dbo].[GrupoClausula_Tx_Producto] 
	@IdTipoGrupoClausula	INT = 0,
	@CodigoPais				INT = 0,
	@Anual					BIT = NULL,
	@IdProducto				INT = 0,
	@CodigoProducto			VARCHAR(120) = '',
	@Sufijo					VARCHAR(20) = NULL,
	@CodigoTarifa			VARCHAR(120) = NULL,
	@IdEstadoEliminado		INT = 25002
	with recompile
AS
BEGIN
	SELECT Grupo.*
	FROM GrupoClausula Grupo
	INNER JOIN Portal.Locacion.Pais ON Grupo.IdLocacion = Pais.IdLocacion
	WHERE (@CodigoPais = 0 OR Pais.Codigo = @CodigoPais)
	AND (@IdTipoGrupoClausula = 0 OR Grupo.IdTipoGrupoClausula = @IdTipoGrupoClausula)
	AND(Grupo.IdEstado <> @IdEstadoEliminado)
	AND
		(EXISTS (
			SELECT  TOP 1 1
			FROM ObjetoAgrupadorClausula Objeto
			INNER JOIN Tarifa ON Objeto.IdObjetoAgrupador = Tarifa.IdTarifa
			INNER JOIN Producto ON Tarifa.IdProducto = Producto.IdProducto
			WHERE Objeto.IdGrupoClausula = Grupo.IdGrupoClausula
			AND	Objeto.IdEstado <> @IdEstadoEliminado
			AND	(@IdProducto = 0 OR Tarifa.IdProducto = @IdProducto) 
			AND	(@CodigoProducto = '' OR @CodigoProducto = '0' OR Producto.Codigo = @CodigoProducto)
			AND	(@Sufijo IS NULL OR Tarifa.Sufijo = @Sufijo) 
			AND	(@CodigoTarifa IS NULL OR Tarifa.Codigo = @CodigoTarifa)
			AND	(@Anual IS NULL OR Tarifa.Anual = @Anual)))

END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda grupo clausulas
-- =============================================
ALTER PROCEDURE [dbo].[GrupoClausula_Tx_Tarifa]
	@CodigoPais			INT = 0,
	@CodigoProducto		VARCHAR(120) = NULL,
	@CodigoTarifa		VARCHAR(120) = NULL,
	@Anual				BIT = 0,
	@IdEstadoEliminado  INT = 25002
AS
BEGIN
	SELECT DISTINCT Grupo.*
	FROM dbo.Producto
	INNER JOIN dbo.Tarifa ON Tarifa.Anual = @Anual AND Producto.IdProducto = Tarifa.IdProducto
	INNER JOIN dbo.ObjetoAgrupadorClausula Objeto ON Objeto.IdObjetoAgrupador = Tarifa.IdTarifa AND Objeto.IdTipoGrupoClausula = Tarifa.IdTipoGrupoClausula
	INNER JOIN dbo.GrupoClausula Grupo ON Objeto.IdGrupoClausula = Grupo.IdGrupoClausula AND Objeto.IdTipoGrupoClausula = Grupo.IdTipoGrupoClausula
	WHERE Objeto.IdEstado <> @IdEstadoEliminado
		AND	Grupo.IdEstado <> @IdEstadoEliminado
		AND	(@CodigoPais = 0 OR Producto.CodigoPais = @CodigoPais)
		AND	(@CodigoProducto IS NULL OR Producto.Codigo = @CodigoProducto)
		AND	(@CodigoTarifa IS NULL OR Tarifa.Codigo = @CodigoTarifa)
END

GO
-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Modificacion masiva leyendas
-- =============================================
ALTER PROCEDURE [dbo].[Leyenda_M_ContenidoClausulaRango]
	@IdGrupoClausula		INT,
	@IdClausula				INT,
	@EdadMinima				INT = -1,
	@EdadMaxima				INT = -1,
	@IdTipoPlan				INT = -1,
	@IdTipoModalidad		INT = -1,
	@Categoria				INT = -1,
	@IdEstadoEliminado		INT,
	@IdIdioma				INT,
	@Texto					VARCHAR(500)
AS
DECLARE
	@SinRangoEdad			INT = 0
BEGIN

	SELECT @SinRangoEdad = COUNT(1) 
	FROM dbo.Clausula
	INNER JOIN  dbo.TipoClausula  ON Clausula.IdTipoClausula = TipoClausula.IdTipoClausula AND Clausula.IdClausula = @IdClausula 
	WHERE (TipoClausula.Codigo <> 'GRAL' AND TipoClausula.Codigo <> 'EKIT' AND TipoClausula.Codigo <> 'NOEKIT')
	
	UPDATE
		Leyenda
	SET	Texto = @Texto
	WHERE IdIdioma = @IdIdioma
	AND IdEstado <> @IdEstadoEliminado
	AND IdContenidoClausulaRango IN (
			SELECT IdContenidoClausulaRango
			FROM ContenidoClausulaRango
			WHERE IdEstado <> @IdEstadoEliminado
				AND (@SinRangoEdad = 0 OR @EdadMinima = -1 OR EdadMinima = @EdadMinima)
				AND	(@SinRangoEdad = 0 OR @EdadMaxima = -1 OR EdadMaxima = @EdadMaxima)
				AND	(@SinRangoEdad = 0 OR @IdTipoPlan = -1 OR IdTipoPlan = @IdTipoPlan)
				AND	(@SinRangoEdad = 0 OR @IdTipoModalidad = -1 OR IdTipoModalidad = @IdTipoModalidad)
				AND	(@SinRangoEdad = 0 OR @Categoria = -1 OR Categoria = @Categoria)
				AND	IdContenidoClausula IN (
						SELECT IdContenidoClausula
						FROM ContenidoClausula Contenido
						WHERE Contenido.IdEstado <> @IdEstadoEliminado
						AND	Contenido.IdGrupoClausula = @IdGrupoClausula
						AND	Contenido.IdClausula = @IdClausula))
END
GO



-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Leyenda
-- =============================================
ALTER PROCEDURE [dbo].[LeyendaMasiva_E]
	@IdContenidoClausulaRango		INT,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	UPDATE
		Leyenda
	SET
		IdEstado = @IdEstadoEliminado
	WHERE
		IdContenidoClausulaRango = @IdContenidoClausulaRango
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Busqueda
-- =============================================
ALTER PROCEDURE [dbo].[ObjetoAgrupadorClausula_Tx_IdGrupoClausula]
	@IdGrupoClausula		INT,
	@IdEstadoEliminado		INT = 25002
AS
BEGIN
	SELECT *
	FROM
		ObjetoAgrupadorClausula
	WHERE
		IdGrupoClausula = @IdGrupoClausula
	AND
		IdEstado <> @IdEstadoEliminado
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Borra masivamente
-- =============================================
ALTER PROCEDURE [dbo].[ObjetoAgrupadorClausulaMasiva_E]
	@IdGrupoClausula				INT,
	@IdEstadoEliminado				INT = 25002
AS
BEGIN
	UPDATE
		ObjetoAgrupadorClausula
	SET
		IdEstado = @IdEstadoEliminado
	WHERE
		IdGrupoClausula = @IdGrupoClausula
	AND
		IdEstado <> @IdEstadoEliminado
	
END

GO


-- ============================================================
-- Author:		Joaquin de las Heras
-- Create date: 26/09/2011
-- Description:	Lista de países que tienen productos asociados
-- ============================================================
ALTER PROCEDURE [dbo].[Pais_Tx_Producto]
	 @IdEstadoEliminado INT = 25002
AS
BEGIN

	SELECT DISTINCT Pais.*, Locacion.Nombre
	FROM Portal.Locacion.Pais
	INNER JOIN Portal.Locacion.Locacion ON Pais.IdLocacion = Locacion.IdLocacion
	INNER JOIN dbo.Producto ON Producto.CodigoPais = Pais.Codigo
	WHERE Locacion.IdEstado <> @IdEstadoEliminado
	ORDER BY Locacion.Nombre ASC;
	
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 25-02-2010
-- Description:	Busqueda tarifa por producto y pais
-- =============================================
ALTER PROCEDURE [dbo].[Tarifa_Tx_IdProducto_IdGrupoClausula]
	@IdGrupoClausula		INT,
	@IdTipoGrupoClausula	INT,
	@IdEstadoEliminado		INT = 25002,
	@Sufijo			VARCHAR(120) = null
AS
BEGIN
	SELECT DISTINCT Tarifa.*
	FROM Tarifa
	INNER JOIN ObjetoAgrupadorClausula ON ObjetoAgrupadorClausula.IdGrupoClausula = @IdGrupoClausula
			AND ObjetoAgrupadorClausula.IdTipoGrupoClausula = @IdTipoGrupoClausula
			AND ObjetoAgrupadorClausula.IdTipoGrupoClausula = Tarifa.IdTipoGrupoClausula
			AND ObjetoAgrupadorClausula.IdObjetoAgrupador = Tarifa.IdTarifa
	WHERE (@Sufijo IS NULL OR Sufijo = @Sufijo)
	AND	ObjetoAgrupadorClausula.IdEstado <> @IdEstadoEliminado
	ORDER BY 
		Tarifa.Sufijo
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 25-02-2010
-- Description:	Busqueda tarifa por producto y pais
-- =============================================
ALTER PROCEDURE [dbo].[Tarifa_Tx_IdProducto_Not_Grupo]
	@IdProducto				INT,
	@CodigoPais				INT,
	@Codigo					VARCHAR(120) = '',
	@Anual					BIT = NULL,
	@Activa					BIT = NULL,
	@IdGrupoClausula		INT,
	@IdTipoGrupoClausula	INT,
	@IdEstadoEliminado		INT = 25002,
	@Sufijo					VARCHAR(120) = null
AS
BEGIN
	SELECT *
	FROM
		Tarifa
	WHERE
		IdProducto = @IdProducto
	AND	CodigoPais = @CodigoPais
	AND	(@Codigo IS NULL OR @Codigo = '' OR Codigo = @Codigo)
	AND	(@Anual IS NULL OR Anual = @Anual)
	AND	(@Activa IS NULL OR Activa = @Activa)
	AND	(@Sufijo IS NULL OR Sufijo = @Sufijo)
	AND	NOT EXISTS (SELECT TOP 1 1 FROM ObjetoAgrupadorClausula 
					WHERE IdTipoGrupoClausula = @IdTipoGrupoClausula 
						AND IdObjetoAgrupador = Tarifa.IdTarifa 
						AND ObjetoAgrupadorClausula.IdEstado <> @IdEstadoEliminado)
		
	ORDER BY Tarifa.Sufijo
END

GO

-- =============================================
-- Author:		Joaquin de las Heras
-- Create date: 25/11/2010
-- Description:	Busqueda textos por parametros
-- =============================================
ALTER PROCEDURE [dbo].[Texto_R_Idioma_Parametros]
	@Nombre				VARCHAR(50) = NULL,
	@IdIdioma			INT = 0,
	@IdTipoTexto		INT,
	@IdEstadoEliminado	INT = 25002
AS
BEGIN
	SELECT * FROM Texto
	INNER JOIN  Texto_R_Idioma ON Texto.IdTexto = Texto_R_Idioma.IdTexto
	WHERE
		Texto.IdEstado <> @IdEstadoEliminado
	AND
		Texto.IdTipoTexto = @IdTipoTexto
	AND
		(@Nombre IS NULL OR Texto.Nombre LIKE '%' + @Nombre + '%')
	AND
		(@IdIdioma = 0 OR Texto_R_Idioma.IdIdioma = @IdIdioma)
END


GO


Print 'Fin del proceso'