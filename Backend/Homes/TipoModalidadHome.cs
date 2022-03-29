using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoModalidadHome : TipoObjetoCodificadoHome<TipoModalidad>
    {
        public static TipoModalidad Obtener(int Id)
        {
            return DAOTipoModalidad.Instancia().Obtener(Id);
        }

        public static IList<TipoModalidad> Buscar()
        {
            return DAOTipoModalidad.Instancia().Buscar();
        }

        public static TipoModalidad Obtener(string Codigo)
        {
            return DAOTipoModalidad.Instancia().Obtener(Codigo);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoModalidadHome.Obtener(Id);
        }

        protected override IList<TipoModalidad> BuscarObjetos()
        {
            return TipoModalidadHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoModalidad (Codigo, Descripcion) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Descripcion + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoModalidad SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Descripcion = '" + Objeto.Descripcion + "' " +
                "WHERE IdTipoModalidad = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoModalidad " +
                "WHERE IdTipoModalidad = " + Objeto.Id;

            return Sql;
        }

    }
}
