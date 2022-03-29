using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DTO;
using Backend.Dominio;

namespace Backend.Homes
{
    public class GrupoCondicionesHome
    {
        private static Leyenda ObtenerLeyenda(int IdIdioma, ContenidoClausulaRango Contenido)
        {
            foreach (Leyenda Leyenda in Contenido.Leyendas)
            {
                if (Leyenda.IdIdioma == IdIdioma)
                {
                    return Leyenda;
                }
            }
            return Contenido.Leyendas.Count > 0 ?
                Contenido.Leyendas[0] : new Leyenda(1, "-");
        }

        private static GrupoCondicionesRangoDTO CrearRango(int IdIdioma, ContenidoClausulaRango Rango)
        {
            GrupoCondicionesRangoDTO RangoDTO = new GrupoCondicionesRangoDTO();

            RangoDTO.EdadMinima = Rango.EdadMinima;
            RangoDTO.EdadMaxima = Rango.EdadMaxima;
            RangoDTO.TipoPlan = Rango.TipoPlan.Descripcion;
            RangoDTO.TipoModalidad = Rango.TipoModalidad.Descripcion;
            RangoDTO.ValidezTerritorial = Rango.ValidezTerritorial.Nombre;
            RangoDTO.Categoria = Rango.Categoria;
            RangoDTO.Leyenda = ObtenerLeyenda(IdIdioma, Rango).Texto;

            return RangoDTO;
        }

        private static Clausula_Idioma ObtenerTitulo(int IdIdioma, Clausula Clausula)
        {
            if (Clausula.Clausula_Idioma != null)
            {
                foreach (Clausula_Idioma Titulo in Clausula.Clausula_Idioma)
                {
                    if (Titulo.IdIdioma == IdIdioma)
                    {
                        return Titulo;
                    }
                }
            }
            return Clausula.Clausula_Idioma != null && Clausula.Clausula_Idioma.Count > 0 ? 
                Clausula.Clausula_Idioma[0] : new Clausula_Idioma();
        }

        //private static Leyenda ObtenerLeyenda(int IdIdioma, ContenidoClausula Contenido)
        //{
        //    foreach (Leyenda Leyenda in Contenido.Leyendas)
        //    {
        //        if (Leyenda.IdIdioma == IdIdioma)
        //        {
        //            return Leyenda;
        //        }
        //    }
        //    return Contenido.Leyendas.Count > 0 ? 
        //        Contenido.Leyendas[0] : new Leyenda(1, "-");
        //}

        private static GrupoCondicionesDTO CrearGrupo(ContenidoClausula Contenido, int IdIdioma)
        {
            GrupoCondicionesDTO Condicion = new GrupoCondicionesDTO();

            Condicion.CodigoClausula = Contenido.Clausula.Codigo;
            Condicion.TituloClausula = ObtenerTitulo(IdIdioma, Contenido.Clausula).Nombre;
            //Condicion.LeyendaClausula = ObtenerLeyenda(IdIdioma, Contenido).Texto;

            foreach (ContenidoClausulaRango Rango in Contenido.Contenidos)
            {
                Condicion.Rangos.Add(CrearRango(IdIdioma, Rango));
            }

            return Condicion;
        }

        public static IList<GrupoCondicionesDTO> Buscar(int IdGrupoClausula, int IdIdioma)
        {
            GrupoClausula GrupoClausula = GrupoClausulaHome.Obtener(IdGrupoClausula);

            IList<GrupoCondicionesDTO> Condiciones = new List<GrupoCondicionesDTO>();

            foreach (ContenidoClausula Contenido in GrupoClausula.Contenidos)
            {
                Condiciones.Add(CrearGrupo(Contenido, IdIdioma));
            }

            return Condiciones;
        }
    }
}
