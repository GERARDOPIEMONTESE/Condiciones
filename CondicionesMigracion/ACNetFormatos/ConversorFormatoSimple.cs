using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using CondicionesMigracion.ACNetDatos;
using Backend.Homes;
using Backend.Dominio;
using CondicionesMigracion.ACNet;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoSimple : IConversorFormato
    {

        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            ContenidoRangoDTO Rango = new ContenidoRangoDTO();
            Rango.Contenido = "MONTO: MENOR-IGUAL " + Datos[0].Valor + " " +
                ObtenerMoneda(Datos[0]) +
                " && REFERENCIA-POLIZAS: IGUAL " + (Datos[0].ReferenciaPolizas == 1) +
                (Datos[0].InformacionAdicional.Length > 0 ? " && INFORMACION-ADICIONAL: IGUAL " + Datos[0].InformacionAdicional : "");
            Rango.IdValidezTerritorial = ValidezTerritorialHome.Obtener("TODO EL MUNDO").Id;
            
            Rango.IdValidezTerritorialClausula = Datos[0].EsNacional != null && Datos[0].EsNacional.ToUpper().Trim().Equals("S") ?
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
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
