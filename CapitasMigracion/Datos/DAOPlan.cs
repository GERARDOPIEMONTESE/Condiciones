using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOPlan : DAOObjetoCodificado<Plan>
    {
        #region Singleton

        private static DAOPlan _Instancia;

        private DAOPlan()
        {
        }

        public static DAOPlan Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOPlan();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string TODOS = "SELECT DISTINCT ACMembershipBusiness.ID BusinessCode, ACMembershipPlan.*, ACCountry.NCode CountryCode FROM ACMembershipCBP, ACMembershipBusiness, ACCountry, ACMembershipPlan WHERE ACMembershipCBP.BusinessID = ACMembershipBusiness.ID AND ACMembershipCBP.PlanID = ACMembershipPlan.ID AND ACMembershipBusiness.OnlyOneCountryID = ACCountry.ID";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(Plan ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.Nombre = dr["Name"].ToString();
            ObjetoPersistido.Codigo = dr["ID"].ToString();
            ObjetoPersistido.CodigoBusiness = dr["BusinessCode"].ToString();
            ObjetoPersistido.CodigoPais = Convert.ToInt32(dr["CountryCode"]);
        }

        public IList<Plan> Buscar()
        {
            return Buscar(TODOS);
        }

    }
}
