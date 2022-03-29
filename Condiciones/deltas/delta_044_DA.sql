UPDATE CONDICIONES.dbo.ContenidoClausulaRango SET CONDICIONES.dbo.ContenidoClausulaRango.IdValidezTerritorialClausula = 3, FechaModificacion = GETDATE()
OUTPUT deleted.IdContenidoClausulaRango, deleted.IdValidezTerritorialClausula INTO CONDICIONES.dbo.CCRBackup(IdContenidoClausulaRango, IdValidezTerritorialClausula)
FROM CONDICIONES.dbo.ContenidoClausulaRango CdCCR
INNER JOIN CONDICIONES.dbo.ContenidoClausula CdCC ON CdCCR.IdContenidoClausula = CdCC.IdContenidoClausula
INNER JOIN CONDICIONES.dbo.GrupoClausula CdGC ON CdCC.IdGrupoClausula = CdGC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.ObjetoAgrupadorClausula CdOAC ON CdGC.IdGrupoClausula = CdOAC.IdGrupoClausula
INNER JOIN CONDICIONES.dbo.Tarifa CdT ON CdOAC.IdObjetoAgrupador = CdT.IdTarifa
INNER JOIN CONDICIONES.dbo.Producto CdP ON CdT.IdProducto = CdP.IdProducto
--Mi búsqueda
WHERE CdP.Codigo IN ('6A','6B','6C','6D','6E','6F','6G','6I','6J','6L','6M','6N','6Q','6K','6R','XO','XP','HA','HB','HC','HD','HE','HF','1U','1V','1W','1Z','1Y','1Z','WR') AND CdP.CodigoPais IN (540,591,560,570,506,809,998,580,582)
--Saco los IdEstado 25002
AND CdCCR.IdEstado IN (25000,25001) AND CdCC.IdEstado IN (25000,25001) AND CdGC.IdEstado IN (25000,25001) AND CdOAC.IdEstado IN (25000,25001)