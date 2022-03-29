using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using Backend.Homes;
using Backend.Dominio;
using CondicionesMigracion.ACNetDatos;
using CondicionesMigracion.ACNet;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoEuroTotal : IConversorFormato
    {

        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            ContenidoRangoDTO RangoEuropa = new ContenidoRangoDTO();

            RangoEuropa.IdValidezTerritorial = ValidezTerritorialHome.Obtener("EUROPA").Id;
            string Contenido = "MONTO: MENOR-IGUAL " +
                Datos[0].Valor + " " +
                ObtenerMoneda(Datos[0]) +
                " && DESTINADO: IGUAL ENFERMEDADES";

            Contenido += " || MONTO: MENOR-IGUAL " +
                Datos[1].Valor + " " +
                ObtenerMoneda(Datos[1]) +
                " && DESTINADO: IGUAL ACCIDENTES";

            Contenido += " || MONTO: MENOR-IGUAL " +
                Datos[2].Valor + " " +
                ObtenerMoneda(Datos[2]) +
                " && DESTINADO: IGUAL REPATRIACIONES";

            ContenidoRangoDTO RangoRestoDelMundo = new ContenidoRangoDTO();
            RangoEuropa.IdValidezTerritorial = ValidezTerritorialHome.Obtener("TODOS (-EUROPA)").Id;

            RangoEuropa.IdValidezTerritorialClausula = Datos[0].EsNacional != null && Datos[0].EsNacional.ToUpper().Trim().Equals("S") ?
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
            RangoEuropa.Categoria = Grupo.Categoria;
            RangoEuropa.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
            RangoEuropa.IdTipoPlan = ObtenerIdTipoPlan(Grupo);
            RangoEuropa.Leyendas = ObtenerLeyendas(Datos[0]);

            RangoRestoDelMundo.Contenido = "MONTO: MENOR-IGUAL " + 
                Datos[2].Valor + " " +
                ObtenerMoneda(Datos[2]);
            
            RangoRestoDelMundo.IdValidezTerritorialClausula = Datos[2].EsNacional != null && Datos[2].EsNacional.ToUpper().Trim().Equals("S") ?
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
            RangoRestoDelMundo.Categoria = Grupo.Categoria;
            RangoRestoDelMundo.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
            RangoRestoDelMundo.IdTipoPlan = ObtenerIdTipoPlan(Grupo);
            RangoRestoDelMundo.Leyendas = ObtenerLeyendas(Datos[2]);

            Rangos.Add(RangoEuropa);
            Rangos.Add(RangoRestoDelMundo);

            return Rangos;
        }

        #endregion
    }
}
