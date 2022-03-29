using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class AsociacionTextoHome
    {
        public static IList<AsociacionTexto> Buscar(int IdGrupoClausula)
        {
            return DAOAsociacionTexto.Instancia().Buscar(IdGrupoClausula);
        }

        public static AsociacionTexto Obtener(int Id)
        {
            return DAOAsociacionTexto.Instancia().Obtener(Id);
        }
    }
}
