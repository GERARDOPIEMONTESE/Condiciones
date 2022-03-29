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
    public class ConversorFormatoAge : IConversorFormato
    {

        #region IConversorFormato Members

        //private string ObtenerValidezTerritorial(ClausulaDato Dato)
        //{
        //    GrupoPais GrupoPais = DAOGrupoPais.Instancia().Obtener(
        //        Dato.IdGrupo, Dato.IdClausula, Dato.PosicionRegistro);

        //    return GrupoPais.Id == 0 ? "" : GrupoPais.Nombre;
        //}

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();
            
            foreach (ClausulaDato Dato in Datos)
            {
                ContenidoRangoDTO Rango = new ContenidoRangoDTO();
                Rango.EdadMinima = Dato.EdadA;
                Rango.EdadMaxima = Dato.EdadB == 0 ? 120 : Dato.EdadB;
                Rango.IdValidezTerritorial = ValidezTerritorialHome.Obtener(
                    ObtenerValidezTerritorial(Dato)).Id;
                Rango.IdValidezTerritorialClausula = Dato.EsNacional != null && Dato.EsNacional.ToUpper().Trim().Equals("S") ?
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.NACIONAL).Id :
                    ValidezTerritorialClausulaHome.Obtener(ValidezTerritorialClausula.INTERNACIONAL).Id;
                Rango.Categoria = Grupo.Categoria;

                Rango.Contenido = "MONTO: MENOR-IGUAL " + Dato.Valor + " " + ObtenerMoneda(Dato);
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
