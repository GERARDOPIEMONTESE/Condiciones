using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoCobertura : DAOObjetoCodificado<TipoCobertura>
    {
        #region Singleton

        private static DAOTipoCobertura _Instancia;

        private DAOTipoCobertura()
        {
        }

        public static DAOTipoCobertura Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoCobertura();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoCobertura ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoCobertura"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        public IList<TipoCobertura> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoCobertura_Tx_Nombre"));
        }

        public TipoCobertura Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoCobertura_Tx_Nombre"));
        }
    }
}
