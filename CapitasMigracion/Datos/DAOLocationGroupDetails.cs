using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOLocationGroupDetails : DAOObjetoPersistido<LocationGroupDetails>
    {
        #region Singleton

        private static DAOLocationGroupDetails _Instancia;

        private DAOLocationGroupDetails()
        {
        }

        public static DAOLocationGroupDetails Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOLocationGroupDetails();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string POR_LOCATION = "SELECT DISTINCT ACLocationGroupDetails.ID, ACLocationGroupDetails.LocationGroupID, ACCountry.NCode CountryCode FROM ACLocationGroupDetails, ACCountry WHERE ACLocationGroupDetails.CountryId = ACCountry.ID AND ACCountry.NCode IS NOT NULL AND LocationGroupID = ";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(LocationGroupDetails ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.IdLocationGroup = Convert.ToInt32(dr["LocationGroupID"]);
            ObjetoPersistido.CountryCode = Convert.ToInt32(dr["CountryCode"]);
        }

        public IList<LocationGroupDetails> Buscar(int IdLocationGroup)
        {
            return Buscar(POR_LOCATION + IdLocationGroup);
        }
    }
}
