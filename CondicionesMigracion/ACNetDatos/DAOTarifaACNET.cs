using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOTarifaACNET : DAOObjetoCodificado<TarifaACNET>
    {
        #region Queries 

        //private const string ALL = "SELECT DISTINCT PAIS, PRODUCTO, TARIFA, TO_NUMBER(CANT_DIAS) DIAS, NOMBRE, ACTIVO, PREFIJO_A_IMP FROM ICARD.TARIFAS WHERE TRUNC(FECHA_INICIO_VIG) <= TRUNC(SYSDATE) AND TRUNC(FECHA_FIN_VIG) >= TRUNC(SYSDATE)";
        private const string ALL_PRODUCTOS = "SELECT DISTINCT PAIS, PRODUCTO, TARIFA, CASE TO_NUMBER(CANT_DIAS) WHEN 365 THEN 1 ELSE 0 END ANUAL, NOMBRE, CASE rtrim(ltrim(ACTIVO)) WHEN 'S' THEN 1 ELSE 0 END ACTIVA, PREFIJO_A_IMP, 1 TIPO, TO_NUMBER(MODALIDAD) IdTipoModalidad FROM ICARD.TARIFAS";

        private const string ALL_UPGRADES = "SELECT DISTINCT PAIS, UPGRADE PRODUCTO, TARIFA, CASE TO_NUMBER(CANT_DIAS) WHEN 365 THEN 1 ELSE 0 END ANUAL, NOMBRE, ACTIVO ACTIVA, '' PREFIJO_A_IMP, 2 TIPO, 1 IdTipoModalidad FROM ICARD.TARIFAS_UPGRADE";

        #endregion

        #region Singleton

        private static DAOTarifaACNET _Instancia;

        private DAOTarifaACNET()
        {
        }

        public static DAOTarifaACNET Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTarifaACNET();
            }
            return _Instancia;
        }

        #endregion

        protected override string  NombreConnectionString()
        {
             return "ACNet";
        }

        protected override void Completar(TarifaACNET ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        protected override void Completar(TarifaACNET ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["PAIS"]);
            ObjetoPersistido.Codigo = dr["TARIFA"].ToString();
            ObjetoPersistido.CodigoProducto = dr["PRODUCTO"].ToString();
            //ObjetoPersistido.Anual = Convert.ToInt32(dr["DIAS"]) >= 365;
            ObjetoPersistido.Anual = Convert.ToBoolean(dr["ANUAL"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
            ObjetoPersistido.Activa = Convert.ToBoolean(dr["ACTIVA"]);
            ObjetoPersistido.Sufijo = DBNull.Value.Equals(dr["PREFIJO_A_IMP"]) ? "" : dr["PREFIJO_A_IMP"].ToString();
            ObjetoPersistido.Tipo = Convert.ToInt32(dr["TIPO"]);
            ObjetoPersistido.IdTipoModalidad = Convert.ToInt32(dr["IdTipoModalidad"]);
        }

        public IList<TarifaACNET> BuscarProductos() 
        {
            return BuscarOracle(ALL_PRODUCTOS);
        }

        public IList<TarifaACNET> BuscarUpgrades()
        {
            return BuscarOracle(ALL_UPGRADES);
        }
    }
}
