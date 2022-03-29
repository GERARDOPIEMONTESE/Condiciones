using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaCodigoPaisGrupo : DAOObjetoPersistido<ClausulaCodigoPaisGrupo>
    {
        #region Queries

        private const string POR_GRUPO = "SELECT * FROM ICARD.GRUPO_PAIS WHERE ID_GRUPO = ";

        #endregion

        #region Singleton

        private static DAOClausulaCodigoPaisGrupo _Instancia;

        private DAOClausulaCodigoPaisGrupo()
        {
        }

        public static DAOClausulaCodigoPaisGrupo Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaCodigoPaisGrupo();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaCodigoPaisGrupo ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        protected override void Completar(ClausulaCodigoPaisGrupo ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.IdGrupo = Convert.ToInt32(dr["ID_GRUPO"]);
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["CODIGO_PAIS"]);
        }

        public IList<ClausulaCodigoPaisGrupo> Buscar(int IdGrupo)
        {
            return BuscarOracle(POR_GRUPO + IdGrupo);
        }
    }
}
