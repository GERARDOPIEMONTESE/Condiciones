using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class AyudaHome
    {
        public static Ayuda Obtener(int Id)
        {
            return DAOAyuda.Instancia().Obtener(Id);
        }

        public static IList<Ayuda> Buscar()
        {
            return DAOAyuda.Instancia().Buscar();
        }
    }
}
