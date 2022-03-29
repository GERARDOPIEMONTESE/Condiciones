using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Homes;
using CondicionesMigracion.ACNetDatos;
using Backend.DTO;
using Backend.Dominio;
using CondicionesMigracion.ACNet;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoRubro : IConversorFormato
    {

        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            ContenidoRangoDTO Rango = new ContenidoRangoDTO();
            Rango.Contenido = "RUBRO: IGUAL " + Datos[0].Rubro +
                (Datos[0].Dias > 0 ? " && REFERENCIA-POLIZA: IGUAL " + (Datos[0].ReferenciaPolizas == 1) : "") +
                " && MONTO: MENOR-IGUAL " + Datos[0].Valor + " " +
                ObtenerMoneda(Datos[0]);

            if (Datos[0].Edad1 > 0)
            {
                Rango.EdadMaxima = Datos[0].Edad1;
            }

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
