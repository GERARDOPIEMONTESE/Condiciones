using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;

namespace Backend.Homes
{
    public class TextoHome
    {
        public static Texto Obtener(int Id)
        {
            return DAOTexto.Instancia().Obtener(Id);
        }

        public static Texto Obtener(int IdTipoTexto, string Nombre)
        {
            return DAOTexto.Instancia().Obtener(IdTipoTexto, Nombre);
        }

        public static IList<Texto> BuscarPorParametros(string Nombre, int IdTipoTexto, int IdIdioma)
        {
            return DAOTexto.Instancia().BuscarPorParametros(Nombre, IdTipoTexto, IdIdioma);
        }

        public static IList<Texto> BuscarPorParametros(string Nombre, int IdTipoTexto, int IdIdioma, int Index, int Cantidad)
        {
            IList<Texto> TextosCompleto = DAOTexto.Instancia().BuscarPorParametros(Nombre, IdTipoTexto, IdIdioma);
            IList<Texto> TextosPaginado = new List<Texto>();

            int Origen = Index * Cantidad;

            for (int I = Origen; I < (Origen + Cantidad) && I < TextosCompleto.Count; I++)
            {
                TextosPaginado.Add(TextosCompleto[I]);
            }

            return TextosPaginado;
        }

        public static IList<Texto> Buscar(int IdTipoTexto, int IdIdioma)
        {
            return DAOTexto.Instancia().BuscarPorParametros(null, IdTipoTexto, IdIdioma);
        }

        public static IList<TextoDTO> Buscar(string Nombre, int IdTipoTexto, int IdIdioma)
        {
            return DAOTextoDTO.Instancia().Buscar(Nombre, IdTipoTexto, IdIdioma);
        }

    }

    public class Texto_IdiomaHome
    {
        public static IList<Texto_Idioma> BuscarPorClausula(int Id)
        {
            return DAOTexto_Idioma.Instancia().BuscarPorTexto(Id);
        }
    }
}
