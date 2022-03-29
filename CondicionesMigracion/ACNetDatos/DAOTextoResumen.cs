using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOTextoResumen : DAOObjetoCodificado<TextoResumen>
    {
        private const string POR_ID = "SELECT * FROM ICARD.CLAUSULA_TEXTO_VOUCHER WHERE ID = ";

        #region Singleton

        private static DAOTextoResumen _Instancia;

        private DAOTextoResumen()
        {
        }

        public static DAOTextoResumen Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTextoResumen();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(TextoResumen ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override void Completar(TextoResumen ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
            ObjetoPersistido.Texto = dr["TEXTO"].ToString();
        }

        public override TextoResumen Obtener(int Id)
        {
            return ObtenerOracle(POR_ID + Id, true);
        }
    }
}
