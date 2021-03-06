USE [Condiciones]
GO
/****** Object:  StoredProcedure [dbo].[TipoImpresionClausula_Tx_IdTipoImpresionClausula]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 23/03/2010
-- Description:	Busqueda tipo impresion
-- =============================================
CREATE PROCEDURE [dbo].[TipoImpresionClausula_Tx_IdTipoImpresionClausula]
	@IdTipoImpresionClausula		INT
AS
BEGIN
	SELECT TOP 1 *
	FROM
		TipoImpresionClausula
	WHERE
		IdTipoImpresionClausula = @IdTipoImpresionClausula
END
GO
/****** Object:  StoredProcedure [dbo].[TipoModalidad_Tx_IdTipoModalidad]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 05/03/2010
-- Description:	Busqueda tipo modalidad
-- =============================================
CREATE PROCEDURE [dbo].[TipoModalidad_Tx_IdTipoModalidad]
	@IdTipoModalidad		INT
AS
BEGIN
	SELECT TOP 1 *
	FROM
		TipoModalidad
	WHERE
		IdTipoModalidad = @IdTipoModalidad
END
GO
/****** Object:  StoredProcedure [dbo].[TipoTextoResumen_Tx_IdTipoTextoResumen]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 15/12/2010
-- Description:	Busqueda tipo texto resumen por id
-- =============================================
CREATE PROCEDURE [dbo].[TipoTextoResumen_Tx_IdTipoTextoResumen]
	@IdTipoTextoResumen			INT
AS
BEGIN
	SELECT TOP 1 *
	FROM
		TipoTextoResumen
	WHERE
		IdTipoTextoResumen = @IdTipoTextoResumen
END
GO
/****** Object:  StoredProcedure [dbo].[Texto_TX_IdTexto]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Texto_TX_IdTexto]
	@IdTexto		INT
AS
BEGIN

	SELECT TOP 1 *
	FROM
		Texto
	WHERE
		Texto.IdTexto = @IdTexto;

END
GO
/****** Object:  StoredProcedure [dbo].[Clausula_Tx_IdClausula]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Clausula_Tx_IdClausula 1
CREATE PROCEDURE [dbo].[Clausula_Tx_IdClausula]
	@IdClausula	INT
AS
BEGIN

	SELECT TOP 1 *
	FROM
		Clausula
	WHERE
		Clausula.IdClausula = @IdClausula
		AND IdEstado <> 25002
			

END
GO
/****** Object:  StoredProcedure [dbo].[Documento_TX_IdDocumento]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Documento_TX_IdDocumento] 
	@IdDocumento	INT

AS
BEGIN
	
	SELECT TOP 1 *
	FROM
		Documento
	WHERE
		Documento.IdDocumento = @IdDocumento;
	
END
GO
/****** Object:  StoredProcedure [dbo].[ContenidoClausula_Tx_IdContenidoClausula]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 14/04/2010
-- Description:	Busqueda contenido clausula por id
-- =============================================
CREATE PROCEDURE [dbo].[ContenidoClausula_Tx_IdContenidoClausula]
	@IdContenidoClausula		INT
AS
BEGIN
	SELECT TOP 1 *
	FROM
		ContenidoClausula
	WHERE
		IdContenidoClausula = @IdContenidoClausula
END
GO
/****** Object:  StoredProcedure [dbo].[Tarifa_Tx_IdTarifa]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 26-02-2010
-- Description:	Busqueda tarifa por Id
-- =============================================
CREATE PROCEDURE [dbo].[Tarifa_Tx_IdTarifa]
	@IdTarifa		INT
AS
BEGIN
	SELECT TOP 1 * 
	FROM
		Tarifa
	WHERE
		IdTarifa = @IdTarifa
END
GO
/****** Object:  StoredProcedure [dbo].[Leyenda_Tx_IdLeyenda]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 05/04/2010
-- Description:	Busqueda Leyenda
-- =============================================
CREATE PROCEDURE [dbo].[Leyenda_Tx_IdLeyenda]
	@IdLeyenda			INT
AS
BEGIN
	SELECT TOP 1 *
	FROM
		Leyenda
	WHERE
		IdLeyenda = @IdLeyenda
END
GO
/****** Object:  StoredProcedure [dbo].[Leyenda_Tx_IdContenidoClausulaRango]    Script Date: 03/09/2012 11:22:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Lorena Cominotti
-- Create date: 05/04/2010
-- Description:	Busqueda Leyenda
-- =============================================
CREATE PROCEDURE [dbo].[Leyenda_Tx_IdContenidoClausulaRango]
	@IdContenidoClausulaRango			INT,
	@IdEstadoEliminado					INT = 25002
AS
BEGIN
	SELECT TOP 3 *
	FROM
		Leyenda
	WHERE
		IdContenidoClausulaRango = @IdContenidoClausulaRango
	AND
		IdEstado <> @IdEstadoEliminado
END
GO
