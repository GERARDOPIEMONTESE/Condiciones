using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaTexto : DAOObjetoPersistido<ClausulaTexto>
    {
        private const string POR_ID = "SELECT * FROM ICARD.CLAUSULA_TEXTOS WHERE ID_TEXTO = ";

        #region Singleton

        private static DAOClausulaTexto _Instancia;

        private DAOClausulaTexto()
        {
        }

        public static DAOClausulaTexto Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaTexto();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaTexto ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override void Completar(ClausulaTexto ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID_TEXTO"]);
            ObjetoPersistido.Descripcion = dr["DESCRIPCION"].ToString();
        }

        public ClausulaTexto ObtenerPorId(int IdTexto)
        {
            return ObtenerOracle(POR_ID + IdTexto, true);
        }

    }
}
