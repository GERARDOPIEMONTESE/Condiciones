using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOMoneda : DAOObjetoCodificado<Moneda>
    {

        #region Queries

        private const string POR_ID = "SELECT * FROM ICARD.MONEDAS WHERE CODIGO = ";

        #endregion

        #region Singleton

        private static DAOMoneda _Instancia;

        private DAOMoneda()
        {
        }

        public static DAOMoneda Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOMoneda();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(Moneda ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["CODIGO"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
            ObjetoPersistido.Nomenclatura = dr["NOMENCLATURA"].ToString();
        }

        protected override void Completar(Moneda ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        private string AgregarId(int Id)
        {
            return "'" + Id + "'";
        }

        public override Moneda Obtener(int Id)
        {
            return ObtenerOracle(POR_ID + AgregarId(Id), true);
        }
    }
}
