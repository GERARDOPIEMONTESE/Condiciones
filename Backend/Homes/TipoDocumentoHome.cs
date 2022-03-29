using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using Backend.Datos;
using Backend.DTO;


namespace Backend.Homes
{
    public class TipoDocumentoHome : TipoObjetoCodificadoHome<TipoDocumento>
    {
        public static IList<TipoDocumento> Buscar()
        {
            return DAOTipoDocumento.Instancia().Buscar();
        }

        public static TipoDocumento Obtener(int Id)
        {
            return DAOTipoDocumento.Instancia().Obtener(Id);
        }

        public override FrameworkDAC.Negocio.ObjetoCodificado ObtenerObjetoCodificado(int Id)
        {
            return TipoDocumentoHome.Obtener(Id);
        }

        protected override IList<TipoDocumento> BuscarObjetos()
        {
            return TipoDocumentoHome.Buscar();
        }

        public override string InsertQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "INSERT INTO TipoDocumento (Nombre) VALUES ('" +
                Objeto.Nombre + "')";

            return Sql;
        }

        public override string UpdateQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "UPDATE TipoDocumento SET " +
                "Nombre = '" + Objeto.Nombre + "' " +
                "WHERE IdTipoDocumento = " + Objeto.Id;

            return Sql;
        }

        public override string DeleteQuery(FrameworkDAC.Negocio.ObjetoCodificado Objeto)
        {
            string Sql = "DELETE TipoDocumento " +
                "WHERE IdTipoDocumento = " + Objeto.Id;

            return Sql;
        }

    }
}
