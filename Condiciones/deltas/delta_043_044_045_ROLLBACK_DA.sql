UPDATE CCR
SET CCR.IdValidezTerritorialClausula = CCRBackup.IdValidezTerritorialClausula
FROM CONDICIONES.dbo.CCRBackup
INNER JOIN CONDICIONES.dbo.ContenidoClausulaRango CCR ON CCR.IdContenidoClausulaRango = CCRBackup.IdContenidoClausulaRango

DELETE FROM CONDICIONES.dbo.CCRBackup