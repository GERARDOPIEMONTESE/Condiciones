using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoGrupoClausulaHome : TipoObjetoCodificadoHome<TipoGrupoClausula>
    {
        public static TipoGrupoClausula Obtener(int Id)
        {
            return DAOTipoGrupoClausula.Instancia().Obtener(Id);
        }

        public static IList<TipoGrupoClausula> Buscar()
        {
            return DAOTipoGrupoClausula.Instancia().Buscar();
        }

        public static TipoGrupoClausula Obtener(string Nombre)
        {
            return DAOTipoGrupoClausula.Instancia().Buscar(Nombre)[0];
        }

        public static TipoGrupoClausula Upgrade()
        {
            return Obtener(TipoGrupoClausula.TARIFA_UPGRADE);
        }

        public static TipoGrupoClausula SLA()
        {
            return Obtener(TipoGrupoClausula.SLA);
        }

        public static TipoGrupoClausula Producto()
        {
            return Obtener(TipoGrupoClausula.TARIFA_PRODUCTO);
        }

        public static TipoGrupoClausula ProductoSinEmision()
        {
            return Obtener(TipoGrupoClausula.PRODUCTO_SIN_EMISION);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoGrupoClausulaHome.Obtener(Id);
        }

        protected override IList<TipoGrupoClausula> BuscarObjetos()
        {
            return TipoGrupoClausulaHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoGrupoClausula (Nombre) VALUES ('" +
                Objeto.Nombre + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoGrupoClausula SET " +
                "Nombre = '" + Objeto.Nombre + "' " +
                "WHERE IdTipoGrupoClausula = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoGrupoClausula " +
                "WHERE IdTipoGrupoClausula = " + Objeto.Id;

            return Sql;
        }

    }
}
