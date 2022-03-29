using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FrameworkDAC.Dato;
using FrameworkDAC.Parametro;
using FrameworkDAC.Negocio;
using Backend.Dominio;

namespace Backend.Datos
{
    public class DAOIdioma : DAOObjetoPersistido<Idioma>
    {
        #region Constantes

        private const string CONNECTIONSTRING = "Portal";

        #endregion

        #region Singleton

        private static DAOIdioma _Instancia;

        private DAOIdioma()
        {
        }

        public static DAOIdioma Instancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new DAOIdioma();
            }
            return _Instancia;
        }

        #endregion

        #region Metodos Redefinidos

        protected override string NombreConnectionString()
        {
            return CONNECTIONSTRING;
        }
        protected override void Completar(Idioma ObjetoPersistido, System.Data.SqlClient.SqlDataReader dr)
        {
            ObjetoPersistido.Id = Convert.ToInt32(dr["IdIdioma"].ToString());
            ObjetoPersistido.Nombre = dr["Descripcion"].ToString();
            ObjetoPersistido.Cultura = dr["Cultura"].ToString();

        }

        #endregion

        #region Metodos

        public IList<Idioma> Buscar()
        {
            Filtro Filtro = new Filtro(new Parametros(), "dbo.Idioma_TT");
            return Buscar(Filtro);
        }

        public Idioma Obtener(string Codigo)
        {
            Parametros Parametros = new Parametros();
            Parametros.AgregarParametro("Codigo", Codigo);

            return Obtener(new Filtro(Parametros, "dbo.Idioma_Tx_Codigo"));
        }

        #endregion

    }
}
