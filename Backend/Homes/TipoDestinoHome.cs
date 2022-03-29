using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoDestinoHome
    {
        public static TipoDestino Obtener(int Id)
        {
            return DAOTipoDestino.Instancia().Obtener(Id);
        }

        public static TipoDestino Obtener(string Nombre)
        {
            return DAOTipoDestino.Instancia().Obtener(Nombre);
        }

        public static IList<TipoDestino> Buscar()
        {
            return DAOTipoDestino.Instancia().Buscar();
        }
    }
}
