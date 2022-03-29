/**
 * Nombre: delta_038_DA.sql
 * Autor: Sebastian Semeraro
 * Accion: ACI9923 - Texto INCLUIDO en clausulas
 * Fecha Creacion: 02/12/2019
 */


UPDATE L SET L.Texto = 'INCLUIDO DENTRO C.4' FROM Leyenda L
WHERE L.IdLeyenda IN (SELECT DISTINCT(L.IdLeyenda) FROM Leyenda L
INNER JOIN ContenidoClausulaRango CCR ON L.IdContenidoClausulaRango = CCR.IdContenidoClausulaRango
INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
WHERE CC.IdClausula IN (SELECT IdClausula FROM Clausula WHERE Codigo IN ('C.4.1.5.2','C.4.3','C.4.5','C.4.6','C.4.8','C.4.13','C.4.14','C.4.16','C.4.19'))
AND L.IdEstado <> 25002 AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
AND P.Codigo IN ('3D','3E','3U','4A','4O','4P','5A','5B','5C','5D','5E','5F','5G','5I','5K','5L','5M','6A','6B','6C','6D','6E','6F','6G','6I','6J','6L','6M','6N','6Q','6K','6R','7C','7D','7T','XO','XP')
AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1
AND L.IdIdioma = 1);

UPDATE L SET L.Texto = 'INCLUDED IN C.4' FROM Leyenda L
WHERE L.IdLeyenda IN (SELECT DISTINCT(L.IdLeyenda) FROM Leyenda L
INNER JOIN ContenidoClausulaRango CCR ON L.IdContenidoClausulaRango = CCR.IdContenidoClausulaRango
INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
WHERE CC.IdClausula IN (SELECT IdClausula FROM Clausula WHERE Codigo IN ('C.4.1.5.2','C.4.3','C.4.5','C.4.6','C.4.8','C.4.13','C.4.14','C.4.16','C.4.19'))
AND L.IdEstado <> 25002 AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
AND P.Codigo IN ('3D','3E','3U','4A','4O','4P','5A','5B','5C','5D','5E','5F','5G','5I','5K','5L','5M','6A','6B','6C','6D','6E','6F','6G','6I','6J','6L','6M','6N','6Q','6K','6R','7C','7D','7T','XO','XP')
AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1
AND IdIdioma = 2);

UPDATE L SET L.Texto = 'INCLUIDO DENTRO C.4' FROM Leyenda L
WHERE L.IdLeyenda IN (SELECT DISTINCT(L.IdLeyenda) FROM Leyenda L
INNER JOIN ContenidoClausulaRango CCR ON L.IdContenidoClausulaRango = CCR.IdContenidoClausulaRango
INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Condiciones.dbo.Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Condiciones.dbo.Producto P ON T.IdProducto = P.IdProducto 
WHERE CC.IdClausula IN (SELECT IdClausula FROM Clausula WHERE Codigo IN ('C.4.1.5.2','C.4.3','C.4.5','C.4.6','C.4.8','C.4.13','C.4.14','C.4.16','C.4.19'))
AND L.IdEstado <> 25002 AND CCR.IdEstado <> 25002 AND CC.IdEstado <> 25002 AND GC.IdEstado <> 25002 AND OAC.IdEstado <> 25002
AND P.CodigoPais IN (540,591,560,570,506,809,593,503,502,504,520,505,507,595,510,598,582,580,998) 
AND P.Codigo IN ('3D','3E','3U','4A','4O','4P','5A','5B','5C','5D','5E','5F','5G','5I','5K','5L','5M','6A','6B','6C','6D','6E','6F','6G','6I','6J','6L','6M','6N','6Q','6K','6R','7C','7D','7T','XO','XP')
AND (T.Sufijo = '' OR T.Sufijo IS NULL) AND T.Activa = 1
AND IdIdioma = 3);