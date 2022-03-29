use Condiciones

update ContenidoClausula
set IdTipoImpresionClausula = 4
where IdClausula in (
select IdClausula from Clausula 
where Codigo in ('C.4.1.2' , 'C.4.5' , 'C.4.8' , 'C.4.12' , 'C.4.13' , 'C.4.14' , 'C.4.16' , 'C.4.19'))
and exists (select 1 
from GrupoClausula g, ObjetoAgrupadorClausula o, Tarifa t
where g.IdGrupoClausula = o.IdGrupoClausula
and o.IdObjetoAgrupador = t.IdTarifa
and t.CodigoPais = 540
and g.IdEstado <> 25002
and o.IdEstado <> 25002
and g.IdGrupoClausula = ContenidoClausula.IdGrupoClausula
)