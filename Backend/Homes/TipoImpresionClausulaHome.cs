using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoImpresionClausulaHome : TipoObjetoCodificadoHome<TipoImpresionClausula>
    {
        public static TipoImpresionClausula Obtener(int Id)
        {
            return DAOTipoImpresionClausula.Instancia().Obtener(Id);
        }

        public static TipoImpresionClausula Obtener(string Codigo)
        {
            return DAOTipoImpresionClausula.Instancia().Obtener(Codigo);
        }

        public static IList<TipoImpresionClausula> Buscar()
        {
            return DAOTipoImpresionClausula.Instancia().Buscar();
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoImpresionClausulaHome.Obtener(Id);
        }

        protected override IList<TipoImpresionClausula> BuscarObjetos()
        {
            return TipoImpresionClausulaHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoImpresionClausula (Codigo, Descripcion) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Descripcion + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoImpresionClausula SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Descripcion = '" + Objeto.Descripcion + "' " +
                "WHERE IdTipoImpresionClausula = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoImpresionClausula " +
                "WHERE IdTipoImpresionClausula = " + Objeto.Id;

            return Sql;
        }

    }
}
