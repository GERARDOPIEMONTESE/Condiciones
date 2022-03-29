using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOLimitCategories : DAOObjetoCodificado<LimitCategories>
    {
        #region Singleton

        private static DAOLimitCategories _Instancia;

        private DAOLimitCategories()
        {
        }

        public static DAOLimitCategories Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOLimitCategories();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string TODOS = "SELECT * FROM ACCaseLimitCategories";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(LimitCategories ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Codigo = dr["GGCCClause"].ToString();
            ObjetoPersistido.Nombre = dr["Name"].ToString();
        }

        public IList<LimitCategories> Buscar()
        {
            return Buscar(TODOS);
        }
    }
}
