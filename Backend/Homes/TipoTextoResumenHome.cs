using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoTextoResumenHome
    {
        public static TipoTextoResumen Obtener(int Id)
        {
            return DAOTipoTextoResumen.Instancia().Obtener(Id);
        }

        public static TipoTextoResumen Obtener(string Codigo)
        {
            return DAOTipoTextoResumen.Instancia().Obtener(Codigo);
        }

        public static IList<TipoTextoResumen> Buscar()
        {
            return DAOTipoTextoResumen.Instancia().Buscar();
        }
    }
}
