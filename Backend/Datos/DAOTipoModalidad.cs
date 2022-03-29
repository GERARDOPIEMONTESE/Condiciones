using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoModalidad : DAOObjetoCodificado<TipoModalidad>
    {
        #region Singleton

        private static DAOTipoModalidad _Instancia;

        private DAOTipoModalidad()
        {
        }

        public static DAOTipoModalidad Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoModalidad();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoModalidad ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoModalidad"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        public IList<TipoModalidad> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoModalidad_Tx_Codigo"));
        }

        public TipoModalidad Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoModalidad_Tx_Codigo"));
        }
    }
}
