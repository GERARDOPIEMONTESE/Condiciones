using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CondicionesMigracion.ACNet;
using FrameworkDAC.Dato;

namespace CondicionesMigracion.ACNetDatos
{
    public class DAOClausulaACNET : DAOObjetoPersistido<ClausulaACNET>
    {
        #region Queries

        private const string CON_TITULO = "SELECT DISTINCT ltrim(rtrim(id_clausula)) ID_CLAUSULA, id_idioma ID_IDIOMA, ltrim(rtrim(titulo)) TITULO FROM icard.clausula_titulo ORDER BY ltrim(rtrim(id_clausula))";

        private const string SIN_TITULO = "SELECT DISTINCT ltrim(rtrim(id_clausula)) ID_CLAUSULA, 1 ID_IDIOMA, 'NINGUNO' TITULO FROM ICARD.CLAUSULA_DATO, ICARD.CLAUSULA_TARIFA_GRUPO WHERE CLAUSULA_DATO.ID_GRUPO = CLAUSULA_TARIFA_GRUPO.ID_GRUPO AND CLAUSULA_TARIFA_GRUPO.FECHA_BAJA IS NULL AND  NOT EXISTS (SELECT 1 FROM icard.clausula_titulo WHERE ltrim(rtrim(clausula_titulo.id_clausula)) = ltrim(rtrim(clausula_Dato.id_clausula)))";

        #endregion

        #region Singleton

        private static DAOClausulaACNET _Instancia;

        private DAOClausulaACNET()
        {
        }

        public static DAOClausulaACNET Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOClausulaACNET();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "ACNet";
        }

        protected override void Completar(ClausulaACNET ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {           
        }

        protected override void Completar(ClausulaACNET ObjetoPersistido, System.Data.OracleClient.OracleDataReader dr)
        {
            ObjetoPersistido.IdClausula = dr["ID_CLAUSULA"].ToString();
            ObjetoPersistido.IdIdioma = Convert.ToInt32(dr["ID_IDIOMA"]);
            ObjetoPersistido.Titulo = dr["TITULO"].ToString();
        }

        public IList<ClausulaACNET> BuscarConTitulo()
        {
            return BuscarOracle(CON_TITULO);
        }

        public IList<ClausulaACNET> BuscarSinTitulo()
        {
            return BuscarOracle(SIN_TITULO);
        }

        public IList<ClausulaACNET> Buscar()
        {
            IList<ClausulaACNET> Clausulas = BuscarConTitulo();

            IList<ClausulaACNET> ClausulasSinTitulo = BuscarSinTitulo();

            foreach (ClausulaACNET Clausula in ClausulasSinTitulo)
            {
                Clausulas.Add(Clausula);
            }

            return Clausulas;
        }
    }
}
