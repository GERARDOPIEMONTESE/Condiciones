using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOValidezTerritorialClausula : DAOObjetoCodificado<ValidezTerritorialClausula>
    {
        #region Singleton

        private static DAOValidezTerritorialClausula _Instancia;

        private DAOValidezTerritorialClausula()
        {
        }

        public static DAOValidezTerritorialClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOValidezTerritorialClausula();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(ValidezTerritorialClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdValidezTerritorialClausula"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<ValidezTerritorialClausula> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.ValidezTerritorialClausula_Tx_Codigo"));
        }

        public ValidezTerritorialClausula Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.ValidezTerritorialClausula_Tx_Codigo"));
        }
    }
}
