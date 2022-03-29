using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;
using Backend.Homes;

namespace Backend.Homes
{
    public class TipoClausulaHome : TipoObjetoCodificadoHome<TipoClausula>
    {
        public static IList<TipoClausula> Buscar()
        {
            return DAOTipoClausula.Instancia().Buscar();
        }

        public static TipoClausula Obtener(string Codigo)
        {
            return DAOTipoClausula.Instancia().Obtener(Codigo);
        }

        public static TipoClausula Obtener(int Id)
        {
            return DAOTipoClausula.Instancia().Obtener(Id);
        }

        public static TipoClausula ObtenerPorCodigoClausula(string CodigoClausula)
        {
            string Codigo = TipoClausula.GENERAL;

            if (CodigoClausula.ToUpper().StartsWith("C."))
            {
                Codigo = TipoClausula.SERVICIO;
            }

            if (CodigoClausula.ToUpper().StartsWith("D."))
            {
                Codigo = TipoClausula.SEGURO;
            }

            return DAOTipoClausula.Instancia().Obtener(Codigo);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoClausulaHome.Obtener(Id);
        }

        protected override IList<TipoClausula> BuscarObjetos()
        {
            return TipoClausulaHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoClausula (Codigo, Nombre) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Nombre + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoClausula SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Nombre = '" + Objeto.Nombre + "' " +
                "WHERE IdTipoClausula = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoClausula " +
                "WHERE IdTipoClausula = " + Objeto.Id;

            return Sql;
        }

    }
}
