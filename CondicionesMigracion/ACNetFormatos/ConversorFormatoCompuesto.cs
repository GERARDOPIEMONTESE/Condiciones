using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using Backend.Homes;
using Backend.Dominio;

namespace CondicionesMigracion.ACNetFormatos
{
    /*
     * ESMVCE
     * INMVCO
     * ESMVCO
     * */
    public class ConversorFormatoCompuesto : IConversorFormato
    {

        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            ContenidoRangoDTO Rango = new ContenidoRangoDTO();
            try
            {
                Rango.Contenido = "MONTO1: MENOR-IGUAL " + Datos[0].Valor + " " +
                    ObtenerMoneda(Datos[0]) +
                    " && MONTO2: MENOR-IGUAL " + Datos[1].Valor + " " +
                    ObtenerMoneda(Datos[1]) +
                    " && UNIDAD-MEDICION: IGUAL " +
                    ObtenerUnidadMedicion(Datos[0]);
            }
            catch (Exception)
            {
                Rango.Contenido = "MONTO1: MENOR-IGUAL " + Datos[0].Valor + " " +
                    ObtenerMoneda(Datos[0]) +
                    " && MONTO2: MENOR-IGUAL " + Datos[1].Valor + " " +
                    ObtenerMoneda(Datos[1]) +
                    " && UNIDAD-MEDICION: IGUAL " +
                    ObtenerUnidadMedicion(Datos[1]);
            }
            Rango.IdValidezTerritorialClausula = Datos[0].EsNacional != null && Datos[0].EsNacional.ToUpper().Trim().Equals("S") ?
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;

            Rango.IdValidezTerritorial = ValidezTerritorialHome.Obtener("TODO EL MUNDO").Id;
            Rango.Categoria = Grupo.Categoria;
            Rango.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
            Rango.IdTipoPlan = ObtenerIdTipoPlan(Grupo);
            Rango.Leyendas = ObtenerLeyendas(Datos[0]);

            Rangos.Add(Rango);

            return Rangos;
        }

        #endregion
    }
}
