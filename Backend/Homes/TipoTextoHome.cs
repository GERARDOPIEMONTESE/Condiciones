using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoTextoHome
    {
        public static TipoTexto Obtener(int Id)
        {
            return DAOTipoTexto.Instancia().Obtener(Id);
        }

        public static TipoTexto Obtener(string Codigo)
        {
            return DAOTipoTexto.Instancia().Obtener(Codigo);
        }

        public static TipoTexto ResumenBeneficios()
        {
            return Obtener(TipoTexto.RESUMEN_BENEFICIOS);
        }

        public static TipoTexto Clausulas()
        {
            return Obtener(TipoTexto.CLAUSULAS);
        }
    }
}
