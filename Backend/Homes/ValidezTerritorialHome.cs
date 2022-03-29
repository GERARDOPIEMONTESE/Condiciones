using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class ValidezTerritorialHome
    {
        public static ValidezTerritorial Obtener(int Id)
        {
            return DAOValidezTerritorial.Instancia().Obtener(Id);
        }

        public static ValidezTerritorial Obtener(string Nombre)
        {
            return DAOValidezTerritorial.Instancia().ObtenerPorNombre(Nombre);
        }

        public static IList<ValidezTerritorial> Buscar()
        {
            return DAOValidezTerritorial.Instancia().Buscar();
        }
    }
}
