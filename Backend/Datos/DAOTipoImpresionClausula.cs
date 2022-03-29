using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoImpresionClausula : DAOObjetoPersistido<TipoImpresionClausula>
    {
        #region Singleton

        private static DAOTipoImpresionClausula _Instancia;

        private DAOTipoImpresionClausula()
        {
        }

        public static DAOTipoImpresionClausula Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoImpresionClausula();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoImpresionClausula ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoImpresionClausula"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<TipoImpresionClausula> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoImpresionClausula_Tx_Codigo"));
        }

        public TipoImpresionClausula Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoImpresionClausula_Tx_Codigo"));
        }
    }
}
