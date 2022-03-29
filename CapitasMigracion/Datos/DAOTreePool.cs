using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAOTreePool : DAOObjetoPersistido<TreePool>
    {
        #region Singleton

        private static DAOTreePool _Instancia;

        private DAOTreePool()
        {
        }

        public static DAOTreePool Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTreePool();
            }

            return _Instancia;
        }

        #endregion

        #region Queries

        private const string TODOS = "SELECT ACCGGTreePool.*, ACCountry.NCode CountryCode, ACMembershipPlan.ID PlanID, ACMembershipBusiness.ID BusinessID FROM ACCGGTreePool, ACMembershipCBP, ACMembershipBusiness, ACMembershipPlan, ACCountry WHERE ACCGGTreePool.MembershipCBPID = ACMembershipCBP.ID AND ACMembershipCBP.BusinessID = ACMembershipBusiness.ID AND ACMembershipCBP.PlanID = ACMembershipPlan.ID AND ACMembershipBusiness.Active = 1 AND ACMembershipBusiness.OnlyOneCountryID = ACCountry.ID";

        #endregion

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(TreePool ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.ParametersToEvaluate = dr["ParametersToEvaluate"].ToString();
            ObjetoPersistido.CountryCode = Convert.ToInt32(dr["CountryCode"]);
            ObjetoPersistido.IdPlan = Convert.ToInt32(dr["PlanID"]);
            ObjetoPersistido.IdBusiness = Convert.ToInt32(dr["BusinessID"]);
        }

        protected override void CompletarComposicion(TreePool ObjetoPersistido)
        {
            ObjetoPersistido.Pools = DAOPool.Instancia().Buscar(ObjetoPersistido.Id);
        }

        public IList<TreePool> Buscar()
        {
            return Buscar(TODOS);
        }
    }
}
