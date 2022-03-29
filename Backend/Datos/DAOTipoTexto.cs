using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoTexto : DAOObjetoCodificado<TipoTexto>
    {
        #region Singleton

        private static DAOTipoTexto _Instancia;

        private DAOTipoTexto()
        {
        }

        public static DAOTipoTexto Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoTexto();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoTexto ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoTexto"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Nombre = dr["Nombre"].ToString();
        }

        public IList<TipoTexto> Buscar()
        {
            return Buscar(new Filtro(new Parametros(), "dbo.TipoTexto_Tx_Nombre"));
        }

        public override TipoTexto Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoTexto_Tx_Codigo"));
        }
    }
}
