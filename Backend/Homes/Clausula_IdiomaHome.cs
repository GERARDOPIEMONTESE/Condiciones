using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace BackendCondiciones.Homes
{
    public class Clausula_IdiomaHome
    {
        public static IList<Clausula_Idioma> BuscarPorClausula(int Id)
        {
            return DAOClausula_Idioma.Instancia().BuscarPorClausula(Id);
        }

    }
}
