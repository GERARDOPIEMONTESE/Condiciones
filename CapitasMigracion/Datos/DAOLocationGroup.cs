using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOLocationGroup : DAOObjetoCodificado<LocationGroup>
    {
        #region Singleton

        private static DAOLocationGroup _Instancia;

        private DAOLocationGroup()
        {
        }

        public static DAOLocationGroup Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOLocationGroup();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string TODOS = "SELECT * FROM ACLocationGroup";

        private const string POR_ID = "SELECT * FROM ACLocationGroup WHERE ID = ";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(LocationGroup ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["Name"].ToString();
            ObjetoPersistido.IncludeNational = Convert.ToBoolean(dr["IncludeNational"]);
        }

        protected override void CompletarComposicion(LocationGroup ObjetoPersistido)
        {
            ObjetoPersistido.Details = DAOLocationGroupDetails.Instancia().Buscar(ObjetoPersistido.Id);
        }

        public IList<LocationGroup> Buscar()
        {
            return Buscar(TODOS);
        }

        public override LocationGroup Obtener(int Id)
        {
            return Obtener(POR_ID + Id);
        }
    }
}
