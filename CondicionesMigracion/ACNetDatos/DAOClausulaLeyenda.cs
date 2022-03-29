using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaLeyenda : DAOObjetoPersistido<ClausulaLeyenda>
    {
        #region Consultas

        private const string POR_GRUPO_POSICION = "SELECT * FROM ICARD.CLAUSULA_LEYENDA WHERE 1 = 1 ";

        #endregion

        #region Singleton

        private static DAOClausulaLeyenda _Instancia;

        private DAOClausulaLeyenda()
        {
        }

        public static DAOClausulaLeyenda Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaLeyenda();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaLeyenda ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
        }

        protected override void Completar(ClausulaLeyenda ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.IdGrupo = Convert.ToInt32(dr["ID_GRUPO"]);
            ObjetoPersistido.Posicion = Convert.ToInt32(dr["POSICION"]);
            ObjetoPersistido.Leyenda = dr["LEYENDA"].ToString();
        }

        private string AgregarGrupo(int IdGrupo)
        {
            return " AND ID_GRUPO = " + IdGrupo;
        }

        private string AgregarPosicion(int Posicion)
        {
            return " AND POSICION = " + Posicion;
        }

        public ClausulaLeyenda Obtener(int IdGrupo, int Posicion)
        {
            return ObtenerOracle(POR_GRUPO_POSICION + 
                AgregarGrupo(IdGrupo) + AgregarPosicion(Posicion), true);
        }
    }
}
