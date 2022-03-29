using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using Backend.Homes;
using CondicionesMigracion.ACNet;
using CondicionesMigracion.ACNetDatos;
using Backend.Dominio;

namespace CondicionesMigracion.ACNetFormatos
{
    public class ConversorFormatoTexto : IConversorFormato
    {

        #region IConversorFormato Members

        //private string ObtenerNombreTexto(ClausulaDato Dato)
        //{
        //    ClausulaTexto Texto = DAOClausulaTexto.Instancia().ObtenerPorId(Dato.IdTexto);

        //    return Texto.Id.ToString();
        //}

        //private string ObtenerTexto(string Nombre)
        //{
        //    Texto Texto = TextoHome.Obtener(Texto.CLAUSULA, Nombre);

        //    return Texto.Id == 0 ? "" : Texto.ContenidoTexto;
        //}

        protected override IList<Backend.DTO.ContenidoRangoDTO> Convertir(ClausulaTarifaGrupo Grupo, IList<CondicionesMigracion.ACNet.ClausulaDato> Datos)
        {
            IList<ContenidoRangoDTO> Rangos = new List<ContenidoRangoDTO>();

            ContenidoRangoDTO Rango = new ContenidoRangoDTO();

            if ("C.5.4.XAM".Equals(Datos[0].IdClausula.ToUpper().Trim()))
            {
                Rango.Contenido = "TEXTO: IGUAL " + ObtenerTexto(ObtenerNombreTexto(Datos[0]));
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
