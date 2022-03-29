using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.Dominio;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;

namespace Backend.Datos
{
    public class DAOTipoAsociacionDocumento : DAOObjetoCodificado<TipoAsociacionDocumento>
    {
        #region Singleton

        private static DAOTipoAsociacionDocumento _Instancia;

        private DAOTipoAsociacionDocumento()
        {
        }

        public static DAOTipoAsociacionDocumento Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOTipoAsociacionDocumento();
            }
            return _Instancia;
        }

        #endregion

        protected override string NombreConnectionString()
        {
            return "Condiciones";
        }

        protected override void Completar(TipoAsociacionDocumento ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdTipoAsociacionDocumento"]);
            ObjetoPersistido.Codigo = dr["Codigo"].ToString();
            ObjetoPersistido.Descripcion = dr["Descripcion"].ToString();
        }

        #region Metodos

        public IList<TipoAsociacionDocumento> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "dbo.TipoAsociacionDocumento_TT");

            return Buscar(Filtro);
        }

        #endregion

        public TipoAsociacionDocumento Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.TipoAsociacionDocumento_Tx_Codigo"));
        }
    }
}
