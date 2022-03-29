UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo IN ('9H','9I','9R','9S','9Q','9L','NN','NM','S01','S02','S03','S04','S05','S06','GQ','GR','GS','GT') AND CdP.CodigoPais = 550
AND (CdT.Sufijo IS NULL OR CdT.Sufijo = '')
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)

UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo = '9R' AND CdP.CodigoPais = 550
AND CdT.Sufijo IN ('BA148','BA149','BA165','BA166')
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)

UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo = '9Q' AND CdP.CodigoPais = 550
AND CdT.Sufijo IN ('BA236','BA336','BA341','BA342','BA344','BA353','BA379')
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)

UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo = '9L' AND CdP.CodigoPais = 550
AND CdT.Sufijo = 'BA451'
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)

UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo = 'S03' AND CdP.CodigoPais = 550
AND CdT.Sufijo IN ('BA568','BA569')
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)