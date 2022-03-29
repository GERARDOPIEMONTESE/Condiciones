using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;

namespace Backend.Homes
{
    public class CompaniaSeguroHome
    {
        public static IList<CompaniaSeguro> Buscar()
        {
            return DAOCompaniaSeguro.Instancia().Buscar();
        }
        public static CompaniaSeguro Obtener(int Id)
        {
            return DAOCompaniaSeguro.Instancia().Obtener(Id);
        }

    }
}
