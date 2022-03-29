using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using Backend.Homes;
using CondicionesMigracion.ACNetDatos;
using CondicionesMigracion.ACNet;
using Backend.Dominio;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoRegular : IConversorFormato
    {

        #region IConversorFormato Members

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            foreach (ClausulaDato Dato in Datos)
            {
                ContenidoRangoDTO Rango = new ContenidoRangoDTO();
                Rango.IdValidezTerritorial = ValidezTerritorialHome.Obtener(
                    ObtenerValidezTerritorial(Dato)).Id;
                
                Rango.IdValidezTerritorialClausula = Dato.EsNacional != null && Dato.EsNacional.ToUpper().Trim().Equals("S") ?
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
                Rango.Categoria = Grupo.Categoria;
                Rango.IdTipoModalidad = TipoModalidadHome.Obtener(TipoModalidad.NO_APLICA).Id;
                Rango.IdTipoPlan = ObtenerIdTipoPlan(Grupo);
                Rango.EdadMinima = Dato.EdadA;
                Rango.EdadMaxima = Dato.EdadB == 0 ? 120 : Dato.EdadB;

                Rango.Contenido = "MONTO: MENOR-IGUAL " + Dato.Valor + " " +
                    ObtenerMoneda(Dato);
                if (Dato.ClausulaAsociada != null) 
                {
                    if (Dato.ClausulaAsociada != null && Dato.ClausulaAsociada.Length > 0)
                    {
                        Rango.Contenido += " && CLAUSULA-ASOCIADA: IGUAL " + Dato.ClausulaAsociada;
                    }                    
                }

                if ("C.5.4.XAM".Equals(Dato.IdClausula.ToUpper().Trim()) 
                                && Dato.IdTexto != null && Dato.IdTexto != 0)
                {
                    Rango.Contenido = "TEXTO: IGUAL " + ObtenerTexto(ObtenerNombreTexto(Dato));
                }

                Rango.Leyendas = ObtenerLeyendas(Dato);

                Rangos.Add(Rango);
            }

            return Rangos;
        }

        #endregion
    }
}
