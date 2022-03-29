using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOGrupoPais : DAOObjetoPersistido<GrupoPais>
    {
        #region Queries

        private const string GRUPO_POR_CLAUSULA = 
            "SELECT ID, ID_CLAUSULA, ID_GRUPO_CLAUSULA, POSICION_CLAUSULA, NOMBRE " +
            "FROM ICARD.clausula_dato_grupo CDG, ICARD.clausula_pais_grupo CPG " +
            "WHERE CDG.ID_GRUPO = CPG.ID ";

        #endregion

        #region Singleton

        private static DAOGrupoPais _Instancia;

        private DAOGrupoPais()
        {
        }

        public static DAOGrupoPais Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOGrupoPais();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(GrupoPais ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            throw new NotImplementedException();
        }

        private string ObtenerCondicion(int IdGrupoClausula, string CodigoClausula, int PosicionClausula)
        {
            return " AND ID_GRUPO_CLAUSULA = " + IdGrupoClausula +
                " AND ID_CLAUSULA = '" + CodigoClausula.ToUpper().Trim() +
                "' AND POSICION_CLAUSULA = " + PosicionClausula;
        }

        protected override void Completar(GrupoPais ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.CodigoClausula = dr["ID_CLAUSULA"].ToString();
            ObjetoPersistido.IdGrupoClausula = Convert.ToInt32(dr["ID_GRUPO_CLAUSULA"]);
            ObjetoPersistido.PosicionClausula = Convert.ToInt32(dr["POSICION_CLAUSULA"]);
            ObjetoPersistido.Nombre = dr["NOMBRE"].ToString();
        }

        public GrupoPais Obtener(int IdGrupoClausula, string CodigoClausula, int PosicionClausula)
        {
            return ObtenerOracle(GRUPO_POR_CLAUSULA + ObtenerCondicion(
                IdGrupoClausula, CodigoClausula, PosicionClausula), true);
        }
    }
}
