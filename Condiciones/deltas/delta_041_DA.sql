/**
 * Nombre: delta_041_DA.sql
 * Autor: Sebastian Semeraro
 * Accion: ACI9923 - Texto INCLUIDO en clausulas
 * Fecha Creacion: 02/12/2019
 */

DECLARE @IdClausula AS INT
DECLARE @OrdenPredefinido AS INT
DECLARE @IdUsuario AS INT
DECLARE @IdTipoImpresionClausula AS INT
DECLARE @IdTipoContenidoImpresion AS INT
DECLARE @EvaluableEnAsistencia AS INT
DECLARE @VisibleEnAsistencia AS INT
DECLARE @TipoCobertura AS INT
DECLARE @EdadMinima AS INT
DECLARE @EdadMaxima AS INT
DECLARE @TipoPlan AS INT 
DECLARE @TipoModalidad AS INT 
DECLARE @Categoria AS INT 
DECLARE @Contenido AS NVARCHAR(2000)
DECLARE @ValidezTerritorialClausula AS INT
DECLARE @ValidezTerritorial AS INT
DECLARE @LeyendaES AS NVARCHAR(1000)
DECLARE @LeyendaEN AS NVARCHAR(1000)
DECLARE @LeyendaPT AS NVARCHAR(1000)

SELECT @IdClausula = IdClausula, @OrdenPredefinido = OrdenPredefinido FROM Clausula WHERE Codigo = '6.'
--SET @IdTipoImpresionClausula = 1 --Ninguno
SET @IdTipoImpresionClausula = 2 --Completo
--SET @IdTipoImpresionClausula = 3 --Solo Imprimir Hoja
--SET @IdTipoImpresionClausula = 4 --Solo Enviar Mail
--SELECT * FROM TipoImpresionClausula

SET @IdTipoContenidoImpresion = 1 --Completo
--SET @IdTipoContenidoImpresion = 2 --Codigo y Contenido
--SET @IdTipoContenidoImpresion = 3 --Descripcion y Contenido
--SET @IdTipoContenidoImpresion = 4 --Contenido
--SELECT * FROM TipoContenidoImpresion
SET @EvaluableEnAsistencia = 1
SET @VisibleEnAsistencia = 1
SET @TipoCobertura = 1 --No Aplica
--SET @TipoCobertura = 2 --Dia
--SET @TipoCobertura = 3 --Mes
--SET @TipoCobertura = 4 --Semestre
--SET @TipoCobertura = 5 --Año
--SET @TipoCobertura = 6 --Viaje
--SET @TipoCobertura = 8 --Evento
--SET @TipoCobertura = 9 --Tarjeta
--SET @TipoCobertura = 10 --Kilogramo
--SELECT * FROM TipoCobertura

SET @IdUsuario = -1 --Usuario usado para alta o modif de base
SET @EdadMinima = 0
SET @EdadMaxima = 120

SET @TipoPlan = 1 --Todos
--SET @TipoPlan = 2 --Plan Familiar
--SET @TipoPlan = 3 --Individual
--SELECT * FROM TipoPlan

SET @TipoModalidad = 1 --No Aplica
--SET @TipoModalidad = 2 --Multitrip 30 Days
--SET @TipoModalidad = 3 --Multitrip 60 Days
--SET @TipoModalidad = 4 --Long Stay Annual
--SET @TipoModalidad = 5 --Long Stay Daily
--SET @TipoModalidad = 6 --Daily
--SET @TipoModalidad = 7 --Multitrip 90 Days
--SET @TipoModalidad = 8 --Multitrip 120 Days
--SET @TipoModalidad = 9 --Capitas
--SET @TipoModalidad = 10 --Multitrip 45 Days
--SELECT * FROM TipoModalidad

SET @Categoria = 0 --Esto es para los ugprades sino 0

SET @Contenido = '' --La fórmula. Ejemplo: 'MONTO: MENOR-IGUAL 500 USD'

--SET @ValidezTerritorialClausula = 1 --Internacional
SET @ValidezTerritorialClausula = 2 --Nacional
--SET @ValidezTerritorialClausula = 3 --Internacional Receptivo
--SET @ValidezTerritorialClausula = 4 --Nacional Receptivo

--SET @ValidezTerritorial = 548 --INTERNACIONAL
SET @ValidezTerritorial = 551
--Hay varios ValidezTerritorial con Nacional, se toma el 551
SET @LeyendaES = ''
SET @LeyendaEN = ''
SET @LeyendaPT = ''

INSERT INTO ContenidoClausula 
            (IdClausula, 
             IdGrupoClausula, 
             IdTipoImpresionClausula, 
             IdTipoContenidoImpresion, 
             EvaluableEnAsistencia, 
             VisibleEnAsistencia, 
             IdLocacion, 
             IdTipoCobertura, 
             Orden, 
             IdUsuario, 
             FechaCreacion, 
             FechaModificacion, 
             IdEstado) 
SELECT @IdClausula, 
       OAC.IdGrupoClausula, 
       @IdTipoImpresionClausula, 
       @IdTipoContenidoImpresion, 
       @EvaluableEnAsistencia, 
       @VisibleEnAsistencia, 
       OAC.IdLocacion, 
       @TipoCobertura, 
       @OrdenPredefinido, 
       @IdUsuario, 
       Getdate(), 
       Getdate(), 
       25000 
FROM   ObjetoAgrupadorClausula OAC 
       INNER JOIN condiciones.dbo.Tarifa T 
               ON OAC.IdObjetoAgrupador = T.IdTarifa 
       INNER JOIN condiciones.dbo.Producto P 
               ON T.IdProducto = P.IdProducto 
WHERE  IdLocacion IN(SELECT IdLocacion 
                     FROM   portal.locacion.Pais 
                     WHERE  Codigo IN(540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998)) 
       AND IdEstado <> 25002 
       AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
       AND P.Codigo IN ('7T') AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1
GROUP  BY IdGrupoClausula, 
          IdLocacion,
		  P.IdProducto; 

INSERT INTO ContenidoClausulaRango 
	(IdContenidoClausula, EdadMinima, EdadMaxima, IdTipoPlan, IdTipoModalidad, Categoria, Contenido, 
	IdValidezTerritorialClausula, IdValidezTerritorial, IdUsuario, FechaCreacion, FechaModificacion, IdEstado, Peso)
SELECT IdContenidoClausula, @EdadMinima, @EdadMaxima, @TipoPlan, @TipoModalidad, @Categoria, @Contenido, 
	@ValidezTerritorialClausula, @ValidezTerritorial, @IdUsuario, GETDATE(), GETDATE(), 25000, NULL from ContenidoClausula CC where
	IdClausula = @IdClausula
	and IdGrupoClausula IN (Select OAC.IdGrupoClausula from ObjetoAgrupadorClausula OAC
	INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
	where 
       P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
       AND P.Codigo IN ('7T')
	AND CC.IdTipoImpresionClausula = @IdTipoImpresionClausula--Completo
	and CC.IdTipoContenidoImpresion = @IdTipoContenidoImpresion--Completo
	and	CC.EvaluableEnAsistencia = @EvaluableEnAsistencia--EvaluableEnAsistencia
	and CC.VisibleEnAsistencia = @VisibleEnAsistencia--VisibleEnAsistencia
	and IdLocacion in (select IdLocacion from Portal.Locacion.Pais where Codigo in(540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) and IdEstado <> 25002)
	and CC.IdTipoCobertura = @TipoCobertura--IdTipoCobertura
	and CC.Orden = @OrdenPredefinido 
	and CC.IdUsuario = @IdUsuario 
	and CC.FechaCreacion > getdate()-1
	and CC.FechaModificacion > getdate()-1
	and CC.IdEstado <> 25002 AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1)

INSERT INTO Leyenda (IdContenidoClausulaRango,IdIdioma,Texto,IdUsuario,FechaCreacion,FechaModificacion,IdEstado)
	SELECT IdContenidoClausulaRango,1,@LeyendaES,@IdUsuario,GETDATE(),GETDATE(),25000 
	FROM ContenidoClausulaRango CCR
	INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
	INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
	INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
	INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
	INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
	WHERE IdClausula = @IdClausula 
	AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
    AND P.Codigo IN ('7T')
	AND CC.FechaCreacion > Convert(Date, GETDATE()-1) 
	AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
	AND CCR.Contenido = @Contenido AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1 GROUP BY CCR.IdContenidoClausulaRango;

INSERT INTO Leyenda (IdContenidoClausulaRango,IdIdioma,Texto,IdUsuario,FechaCreacion,FechaModificacion,IdEstado)
	SELECT IdContenidoClausulaRango,2,@LeyendaEN,@IdUsuario,GETDATE(),GETDATE(),25000 
	FROM ContenidoClausulaRango CCR
	INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
	INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
	INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
	INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
	INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
	WHERE IdClausula = @IdClausula 
	AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
    AND P.Codigo IN ('7T')
	AND CC.FechaCreacion > Convert(Date, GETDATE()-1) 
	AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
	AND CCR.Contenido = @Contenido AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1 GROUP BY CCR.IdContenidoClausulaRango;

INSERT INTO Leyenda (IdContenidoClausulaRango,IdIdioma,Texto,IdUsuario,FechaCreacion,FechaModificacion,IdEstado)
	SELECT IdContenidoClausulaRango,3,@LeyendaPT,-1,GETDATE(),GETDATE(),25000 
	FROM ContenidoClausulaRango CCR
	INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
	INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
	INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
	INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
	INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
	WHERE IdClausula = @IdClausula 
	AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
    AND P.Codigo IN ('7T')
	AND CC.FechaCreacion > Convert(Date, GETDATE()-1) 
	AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
	AND CCR.Contenido = @Contenido AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1 GROUP BY CCR.IdContenidoClausulaRango;
