using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoPlanHome : TipoObjetoCodificadoHome<TipoPlan>
    {
        public static TipoPlan Obtener(int Id)
        {
            return DAOTipoPlan.Instancia().Obtener(Id);
        }

        public static TipoPlan Obtener(string Codigo)
        {
            return DAOTipoPlan.Instancia().Obtener(Codigo);
        }

        public static IList<TipoPlan> Buscar()
        {
            return DAOTipoPlan.Instancia().Buscar();
        }

        public static TipoPlan Todos()
        {
            return DAOTipoPlan.Instancia().Obtener(TipoPlan.CODIGO_TODOS);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoPlanHome.Obtener(Id);
        }

        protected override IList<TipoPlan> BuscarObjetos()
        {
            return TipoPlanHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoPlan (Codigo, Descripcion) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Descripcion + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoPlan SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Descripcion = '" + Objeto.Descripcion + "' " +
                "WHERE IdTipoPlan = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoPlan " +
                "WHERE IdTipoPlan = " + Objeto.Id;

            return Sql;
        }

    }
}
