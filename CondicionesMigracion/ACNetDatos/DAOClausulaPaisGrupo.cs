using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaPaisGrupo : DAOObjetoCodificado<ClausulaPaisGrupo>
    {
        #region Queries

        private const string ALL = "SELECT DISTINCT * FROM ICARD.CLAUSULA_PAIS_GRUPO ";

        #endregion

        #region Singleton

        private static DAOClausulaPaisGrupo _Instancia;

        private DAOClausulaPaisGrupo()
        {
        }

        public static DAOClausulaPaisGrupo Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaPaisGrupo();
            }
            return _Instancia;
        }

        #endregion
        
        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaPaisGrupo ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        protected override void Completar(ClausulaPaisGrupo ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
        }

        public IList<ClausulaPaisGrupo> Buscar()
        {
            return BuscarOracle(ALL);
        }
    }
}
