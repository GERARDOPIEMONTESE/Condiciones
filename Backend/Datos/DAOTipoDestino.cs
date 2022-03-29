using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoDestino : DAOObjetoCodificado<TipoDestino>
    {
        #region Singleton

        private static DAOTipoDestino _Instancia;

        private DAOTipoDestino()
        {
        }

        public static DAOTipoDestino Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoDestino();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoDestino ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoDestino"]);
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        public IList<TipoDestino> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoDestino_Tx_Nombre"));
        }

        public TipoDestino Obtener(string Nombre)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Nombre", Nombre);

            return Obtener(new Filtro(Parametros, "dbo.TipoDestino_Tx_Nombre"));
        }
    }
}
