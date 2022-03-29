using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoCoberturaHome : TipoObjetoCodificadoHome<TipoCobertura>
    {
        public static IList<TipoCobertura> Buscar()
        {
            return DAOTipoCobertura.Instancia().Buscar();
        }

        public static TipoCobertura Obtener(int Id)
        {
            return DAOTipoCobertura.Instancia().Obtener(Id);
        }

        public static TipoCobertura Obtener(string Codigo)
        {
            return DAOTipoCobertura.Instancia().Obtener(Codigo);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoCoberturaHome.Obtener(Id);
        }

        protected override IList<TipoCobertura> BuscarObjetos()
        {
            return TipoCoberturaHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoCobertura (Codigo, Nombre) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Nombre + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoCobertura SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Nombre = '" + Objeto.Nombre + "' " +
                "WHERE IdTipoCobertura = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoCobertura " +
                "WHERE IdTipoCobertura = " + Objeto.Id;

            return Sql;
        }

    }
}
