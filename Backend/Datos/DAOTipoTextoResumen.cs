using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoTextoResumen : DAOObjetoCodificado<TipoTextoResumen>
    {
        #region Singleton

        private static DAOTipoTextoResumen _Instancia;

        private DAOTipoTextoResumen()
        {
        }

        public static DAOTipoTextoResumen Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoTextoResumen();
            }

            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoTextoResumen ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoTextoResumen"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<TipoTextoResumen> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoTextoResumen_Tx_Codigo"));
        }

        public TipoTextoResumen Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoTextoResumen_Tx_Codigo"));
        }
    }
}
