using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class ContenidoClausulaHome
    {
        public static ContenidoClausula Obtener(int IdGrupoClausula, int IdClausula)
        {
            return DAOContenidoClausula.Instancia().Obtener(IdGrupoClausula, IdClausula);
        }

        public static IList<ContenidoClausula> Buscar(int IdGrupoClausula, bool Lazy)
        {
            return DAOContenidoClausula.Instancia().Buscar(IdGrupoClausula, Lazy);
        }
    }
}
