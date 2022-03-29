using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Datos;
using Backend.Dominio;

namespace Backend.Homes
{
    public class TipoAsociacionDocumentoHome : TipoObjetoCodificadoHome<TipoAsociacionDocumento>
    {
        public static TipoAsociacionDocumento Obtener(int Id)
        {
            return DAOTipoAsociacionDocumento.Instancia().Obtener(Id);
        }

        public static TipoAsociacionDocumento Obtener(string Codigo)
        {
            return DAOTipoAsociacionDocumento.Instancia().Obtener(Codigo);
        }

        public static IList<TipoAsociacionDocumento> Buscar()
        {
            return DAOTipoAsociacionDocumento.Instancia().Buscar();
        }

        public static TipoAsociacionDocumento Grupo()
        {
            return DAOTipoAsociacionDocumento.Instancia().
                Obtener(TipoAsociacionDocumento.GRUPO);
        }

        public static TipoAsociacionDocumento Pais()
        {
            return DAOTipoAsociacionDocumento.Instancia().
                Obtener(TipoAsociacionDocumento.PAIS);
        }

        public static TipoAsociacionDocumento Producto()
        {
            return DAOTipoAsociacionDocumento.Instancia().
                Obtener(TipoAsociacionDocumento.PRODUCTO);
        }



        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoAsociacionDocumentoHome.Obtener(Id);
        }

        protected override IList<TipoAsociacionDocumento> BuscarObjetos()
        {
            return TipoAsociacionDocumentoHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoAsociacionDocumento (Codigo, Descripcion) VALUES ('" +
                Objeto.Codigo + "',' " + Objeto.Descripcion + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoAsociacionDocumento SET " +
                "Codigo = '" + Objeto.Codigo + "', " +
                "Descripcion = '" + Objeto.Descripcion + "' " +
                "WHERE IdTipoAsociacionDocumento = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoAsociacionDocumento " +
                "WHERE IdTipoAsociacionDocumento = " + Objeto.Id;

            return Sql;
        }

    }
}
