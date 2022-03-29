using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;

namespace Backend.Homes
{
    public class IdiomaHome
    {
        public static Idioma Obtener(int Id)
        {
            return (Idioma)DAOIdioma.Instancia().Obtener(Id);
        }

        public static IList<Idioma> Buscar()
        {
            return DAOIdioma.Instancia().Buscar();
        }

        public static Idioma Espanol()
        {
            return DAOIdioma.Instancia().Obtener(Idioma.ESPANOL);
        }

        public static Idioma Ingles()
        {
            return DAOIdioma.Instancia().Obtener(Idioma.INGLES);
        }

        public static Idioma Portugues()
        {
            return DAOIdioma.Instancia().Obtener(Idioma.PORTUGUES);
        }
        public static string ObtenerNombreIdioma(int id)
        {
            return DAOIdioma.Instancia().Obtener(id).Nombre;
        }

    
    }
}
