using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOBusiness : DAOObjetoCodificado<Business>
    {
        #region Singleton

        private static DAOBusiness _Instancia;

        private DAOBusiness()
        {
        }

        public static DAOBusiness Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOBusiness();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string TODOS = "SELECT DISTINCT ACMembershipBusiness.*, ACCountry.NCode CountryCode FROM ACMembershipCBP, ACMembershipBusiness, ACCountry, ACMembershipPlan WHERE ACMembershipCBP.BusinessID = ACMembershipBusiness.ID AND ACMembershipCBP.PlanID = ACMembershipPlan.ID AND ACMembershipBusiness.OnlyOneCountryID = ACCountry.ID";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(Business ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["Name"].ToString();
            ObjetoPersistido.Codigo = dr["ID"].ToString();
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["CountryCode"]);
        }

        public IList<Business> Buscar()
        {
            return Buscar(TODOS);
        }
    }
}
