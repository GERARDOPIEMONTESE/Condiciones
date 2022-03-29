using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class ValidezTerritorialClausulaHome
    {
        public static IList<ValidezTerritorialClausula> Buscar()
        {
            return DAOValidezTerritorialClausula.Instancia().Buscar();
        }

        public static ValidezTerritorialClausula Obtener(int Id)
        {
            return DAOValidezTerritorialClausula.Instancia().Obtener(Id);
        }

        public static ValidezTerritorialClausula Obtener(string Codigo)
        {
            return DAOValidezTerritorialClausula.Instancia().Obtener(Codigo);
        }
    }
}
