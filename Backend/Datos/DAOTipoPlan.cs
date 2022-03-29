using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoPlan : DAOObjetoCodificado<TipoPlan>
    {
        #region Singleton

        private static DAOTipoPlan _Instancia;

        private DAOTipoPlan()
        {
        }

        public static DAOTipoPlan Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoPlan();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoPlan ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoPlan"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<TipoPlan> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoPlan_Tx_Codigo"));
        }

        public TipoPlan Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);
            return DAOTipoPlan.Instancia().Obtener(
                new Filtro(Parametros, "dbo.TipoPlan_Tx_Codigo"));
        }
    }
}
