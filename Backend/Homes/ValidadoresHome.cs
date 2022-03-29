using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.Homes;

namespace Backend.Homes
{
    public class ValidadoresHome
    {
        public static Validadores FindById(int Id)
        {
            return DAOValidadores.Instancia().FindById(Id);
        }

        public static IList<Validadores> FindAll()
        {
            return DAOValidadores.Instancia().FindAll();
        }

        public static IList<Validadores> FindAllVisible()
        {
            return DAOValidadores.Instancia().FindAllVisible();
        }
    }
}
