using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using FrameworkDAC.Negocio;
using Backend.Dominio;
using System.Transactions;


namespace Backend.Datos
{
    public class DAOTipoClausula : DAOObjetoCodificado<TipoClausula>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Condiciones";

        #endregion

        #region Singleton

        private static DAOTipoClausula _Instancia;

        private DAOTipoClausula()
        {
        }

        public static DAOTipoClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoClausula();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }
        protected override void Completar(TipoClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoClausula"].ToString());
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        #endregion

        #region Metodos

        public IList<TipoClausula> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "dbo.TipoClausula_TT");
            return Buscar(Filtro);
        }

        public TipoClausula Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoClausula_Tx_Codigo"));
        }

        #endregion


    }
}
