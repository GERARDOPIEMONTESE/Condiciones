using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;

namespace Backend.Homes
{
    public class TipoOperacionHome
    {
        public static IList<TipoOperacion> Buscar()
        {
            return DAOTipoOperacion.Instancia().Buscar();
        }
        public static TipoOperacion Obtener(int IdTipoOperacion) 
        {
            return DAOTipoOperacion.Instancia().Obtener(IdTipoOperacion);
        }
    }
}
