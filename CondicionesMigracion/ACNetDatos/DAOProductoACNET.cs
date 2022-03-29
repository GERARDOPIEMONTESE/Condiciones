using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOProductoACNET : DAOObjetoCodificado<ProductoACNET>
    {
        #region Queries

        private const string ALL = "SELECT DISTINCT PAIS, CODIGO, NOMBRE, 1 TIPO FROM ICARD.PRODUCTOS UNION SELECT DISTINCT PAIS, CODIGO, NOMBRE, 2 TIPO FROM ICARD.UPGRADES";

        #endregion

        #region Singleton

        private static DAOProductoACNET _Instancia;

        private DAOProductoACNET()
        {
        }

        public static DAOProductoACNET Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOProductoACNET();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ProductoACNET ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override void Completar(ProductoACNET ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Pais = Convert.ToInt32(dr["PAIS"]);
            ObjetoPersistido.Codigo = dr["CODIGO"].ToString();
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
            ObjetoPersistido.Tipo = Convert.ToInt32(dr["TIPO"]);
        }

        public IList<ProductoACNET> Buscar()
        {
            return BuscarOracle(ALL);
        }

    }
}
