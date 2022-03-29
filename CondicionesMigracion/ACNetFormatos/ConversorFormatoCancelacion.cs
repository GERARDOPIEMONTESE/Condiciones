using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using Backend.Dominio;
using Backend.Homes;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoCancelacion : IConversorFormato
    {
        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            foreach (ClausulaDato Dato in Datos)
            {
                ContenidoRangoDTO Rango = new ContenidoRangoDTO();

                Rango.Contenido = "MONTO: MENOR-IGUAL " + Dato.Valor + " " + ObtenerMoneda(Dato) + 
                    " && INFORMACION-ADICIONAL: IGUAL " + Dato.InformacionAdicional;
                
                Rango.IdValidezTerritorialClausula = Dato.EsNacional != null && Dato.EsNacional.ToUpper().Trim().Equals("S") ?
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
                Rango.Categoria = Grupo.Categoria;
                Rango.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
                Rango.IdTipoPlan = ObtenerIdTipoPlan(Grupo);
                Rango.Leyendas = ObtenerLeyendas(Dato);

                Rangos.Add(Rango);
            }

            return Rangos;
        }

        #endregion
    }
}
