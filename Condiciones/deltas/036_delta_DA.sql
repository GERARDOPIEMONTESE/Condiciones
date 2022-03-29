--USE Condiciones_post_problema
UPDATE ContenidoClausula SET IdEstado = 25002, FechaModificacion = GETDATE(), IdUsuario = 3
FROM ContenidoClausula CC
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Clausula C ON  CC.IdClausula = C.IdClausula
INNER JOIN Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Producto P ON T.IdProducto = P.IdProducto
WHERE C.Codigo IN ('C.4.10','C.4.10.1','C.4.10.A','C.4.10.PT','D0003','D0003.1') AND P.CodigoPais NOT IN (550,506)
AND GC.IdEstado <> 25002 AND CC.IdEstado <> 25002

UPDATE ContenidoClausulaRango SET IdEstado = 25002, FechaModificacion = GETDATE(), IdUsuario = 3 
FROM ContenidoClausulaRango CCR
INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Clausula C ON  CC.IdClausula = C.IdClausula
INNER JOIN Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Producto P ON T.IdProducto = P.IdProducto
WHERE C.Codigo IN ('C.4.10','C.4.10.1','C.4.10.A','C.4.10.PT','D0003','D0003.1') AND P.CodigoPais NOT IN (550,506)
AND GC.IdEstado <> 25002 

UPDATE Leyenda SET IdEstado = 25002, FechaModificacion = GETDATE(), IdUsuario = 3 FROM Leyenda L
INNER JOIN ContenidoClausulaRango CCR ON L.IdContenidoClausulaRango = CCR.IdContenidoClausulaRango
INNER JOIN ContenidoClausula CC ON CCR.IdContenidoClausula = CC.IdContenidoClausula
INNER JOIN GrupoClausula GC ON CC.IdGrupoClausula = GC.IdGrupoClausula
INNER JOIN ObjetoAgrupadorClausula OAC ON GC.IdGrupoClausula = OAC.IdGrupoClausula
INNER JOIN Clausula C ON  CC.IdClausula = C.IdClausula
INNER JOIN Tarifa T ON OAC.IdObjetoAgrupador = T.IdTarifa
INNER JOIN Producto P ON T.IdProducto = P.IdProducto
WHERE C.Codigo IN ('C.4.10','C.4.10.1','C.4.10.A','C.4.10.PT','D0003','D0003.1') AND P.CodigoPais NOT IN (550,506)
AND GC.IdEstado <> 25002