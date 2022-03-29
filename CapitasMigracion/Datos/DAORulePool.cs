using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapitasMigracion.Dominio;
using FrameworkDAC.Dato;

namespace CapitasMigracion.Datos
{
    public class DAORulePool : DAOObjetoPersistido<RulePool>
    {
        #region Singleton

        public static DAORulePool _Instancia;

        private DAORulePool()
        {
        }

        public static DAORulePool Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAORulePool();
            }

            return _Instancia;
        }

        #endregion

        private const string POR_POOL = "SELECT ACCGGRulePool.ID, ACCGGRulePool.ACCGGPoolID, ACCGGRulePool.Value, ACCGGRulePool.TerritorialValidityLocationGroupID, ACCGGRulePool.Evaluate, ACCGGRuleType.Name RuleType, ACUnit.ISO4217Code Unit, ACCGGRuleRate.Name Rate, ltrim(rtrim(ACLocationGroup.Name)) TerritorialValidity, ACLocationGroup.IncludeNational FROM ACCGGRulePool, ACCGGRuleType, ACUnit, ACCGGRuleRate, ACLocationGroup WHERE ACCGGRulePool.RuleTypeID = ACCGGRuleType.ID AND ACCGGRulePool.ACUnitID = ACUnit.ID AND	ACCGGRulePool.RateId = ACCGGRuleRate.ID AND ACCGGRulePool.TerritorialValidityLocationGroupID = ACLocationGroup.ID AND ACCGGPoolID = ";

        protected override string NombreConnectionString()
        {
            return "Xam";
        }

        protected override void Completar(RulePool ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["ID"]);
            ObjetoPersistido.IdPool = Convert.ToInt32(dr["ACCGGPoolID"]);
            ObjetoPersistido.RuleType = dr["RuleType"].ToString();
            ObjetoPersistido.Value = Convert.ToDecimal(dr["Value"]);
            ObjetoPersistido.Unit = dr["Unit"].ToString();
            ObjetoPersistido.Rate = dr["Rate"].ToString();
            ObjetoPersistido.IdTerritorialValidity = Convert.ToInt32(dr["TerritorialValidityLocationGroupID"]);
            ObjetoPersistido.TerritorialValidity = dr["TerritorialValidity"].ToString();
            ObjetoPersistido.IncludeNational = Convert.ToBoolean(dr["IncludeNational"]);
            ObjetoPersistido.Evaluate = Convert.ToBoolean(dr["Evaluate"]);
        }

        public IList<RulePool> Buscar(int IdPool)
        {
            return Buscar(POR_POOL + IdPool);
        }
    }
}
