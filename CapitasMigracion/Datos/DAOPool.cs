using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace CapitasMigracion.Datos
{
    public class DAOPool : DAOObjetoPersistido<Pool>
    {
        #region Singleton

        private static DAOPool _Instancia;

        private DAOPool()
        {
        }

        public static DAOPool Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOPool();
            }

            return _Instancia;
        }

        #endregion

        private const string POR_TREE = "SELECT * FROM ACCGGPool WHERE ACCGGTreeID = ";

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(Pool ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.IdTreePool = Convert.ToInt32(dr["ACCGGTreeID"]);
            ObjetoPersistido.CodigoClausula = dr["ACCGGName"].ToString();
            ObjetoPersistido.ParentsIds = dr["ParentsID"].ToString();
            ObjetoPersistido.Visible = Convert.ToBoolean(dr["Visible"]);
        }

        protected override void CompletarComposicion(Pool ObjetoPersistido)
        {
            ObjetoPersistido.Rules = DAORulePool.Instancia().Buscar(ObjetoPersistido.Id);
        }

        public IList<Pool> Buscar(int IdTreePool)
        {
            return Buscar(POR_TREE + IdTreePool);
        }
    }
}
