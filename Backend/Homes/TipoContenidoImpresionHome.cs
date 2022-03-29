using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;

namespace Backend.Homes
{
    public class TipoContenidoImpresionHome : TipoObjetoCodificadoHome<TipoContenidoImpresion>
    {
        public static TipoContenidoImpresion Obtener(int Id)
        {
            return DAOTipoContenidoImpresion.Instancia().Obtener(Id);
        }

        public static TipoContenidoImpresion Obtener(string Codigo)
        {
            return DAOTipoContenidoImpresion.Instancia().Obtener(Codigo);
        }

        public static IList<TipoContenidoImpresion> Buscar()
        {
            return DAOTipoContenidoImpresion.Instancia().Buscar();
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoContenidoImpresionHome.Obtener(Id);
        }

        protected override IList<TipoContenidoImpresion> BuscarObjetos()
        {
            return TipoContenidoImpresionHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoContenidoImpresion (Codigo, Descripcion) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Descripcion + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoContenidoImpresion SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Descripcion = '" + Objeto.Descripcion + "' " +
                "WHERE IdTipoContenidoImpresion = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoContenidoImpresion " +
                "WHERE IdTipoContenidoImpresion = " + Objeto.Id;

            return Sql;
        }

    }
}
